using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using NUnit.Framework;

namespace Brownsberger.Commons.UnitTests
{
    [TestFixture]
    public class DataContractSerializerExtensionsFixture
    {
        [Test]
        public void Can_Serialize_Into_UTF8()
        {
            var subject = new Subject {SomeStringProperty = "foo", SomeDateProperty = DateTime.Now.AddDays(2)};
            string xml = subject.DataContractSerialize();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlDeclaration declaration = doc.ChildNodes.OfType<XmlDeclaration>().First();

            Assert.That(string.Equals(declaration.Encoding, "utf-8", StringComparison.InvariantCultureIgnoreCase), Is.True);
        }

        [Test]
        public void Can_Round_Trip_Serialize_And_Deserialize()
        {
            var subject1 = new Subject { SomeStringProperty = "foo", SomeDateProperty = DateTime.Now.AddDays(2) };
            string xml = subject1.DataContractSerialize();

            var subject2 = xml.DataContractDeserialize<Subject>();

            Assert.That(subject1, Is.EqualTo(subject2));
        }

        [DataContract]
        public class Subject
        {
            [DataMember]
            public string SomeStringProperty { get; set; }
            [DataMember]
            public DateTime SomeDateProperty { get; set; }

#pragma warning disable 659
            public override bool Equals(object obj)
#pragma warning restore 659
            {
                Subject subject = obj as Subject;

                if (subject != null)
                {
                    return string.Equals(this.SomeStringProperty, subject.SomeStringProperty) &&
                           DateTime.Equals(this.SomeDateProperty, subject.SomeDateProperty);
                }

                return false;
            }
        }
    }
}