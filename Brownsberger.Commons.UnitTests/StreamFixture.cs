using System.IO;
using System.Text;
using NUnit.Framework;

namespace Brownsberger.Commons.UnitTests
{
    [TestFixture]
    public class StreamFixture
    {
        [Test]
        public void Can_Read_Stream_From_Beginning_To_End_As_A_String()
        {
            string actual;
            const string expected = "foo... bar... baz...";

            using (var stream = new MemoryStream())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(expected);

                stream.Write(bytes, 0, bytes.Length);

                actual = stream.ReadBeginningToEnd();
            }

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
