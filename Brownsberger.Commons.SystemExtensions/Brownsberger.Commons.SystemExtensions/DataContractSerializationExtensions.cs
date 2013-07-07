using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

public static class DataContractSerializerExtensions
{
    public static string DataContractSerialize<T>(this T obj) where T : class
    {
        return new DataContractSerializer(typeof(T)).Serialize(obj.CheckForNullArg("obj"));
    }

    public static T DataContractDeserialize<T>(this string xml)
    {
        return new DataContractSerializer(typeof(T)).Deserialize<T>(xml.CheckForNullArg("xml"));
    }

    public static string Serialize(this DataContractSerializer serializer, object obj)
    {
        obj.CheckForNullArg("obj");

        using (var stream = new MemoryStream())
        {
            using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = new UTF8Encoding(true), Indent = true }))
            {
                serializer.WriteObject(writer, obj);
                writer.Flush();
            }

            stream.Seek(0, SeekOrigin.Begin);

            return stream.ReadBeginningToEnd();
        }
    }

    public static T Deserialize<T>(this DataContractSerializer serializer, string xml)
    {
        xml.CheckForNullArg("obj");

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            return (T)serializer.ReadObject(stream);
        }
    }

    public static string ReadBeginningToEnd(this Stream stream)
    {
        stream.CheckForNullArg("stream");

        stream.Seek(0, SeekOrigin.Begin);

        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}