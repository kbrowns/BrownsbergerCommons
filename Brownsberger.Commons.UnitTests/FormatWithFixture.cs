using NUnit.Framework;

namespace Brownsberger.Commons.UnitTests
{
    [TestFixture]
    public class FormatWithFixture
    {
        [TestCase("foo", new object[] { }, "foo")]
        [TestCase("foo{0}", new object[] { "bar" }, "foobar")]
        [TestCase("foo{0}baz{1}", new object[] { "bar", "bah" }, "foobarbazbah")]
        [TestCase("foo{0}baz{1}123", new object[] { "bar", "bah" }, "foobarbazbah123")]
        public void FormatWith_Suite(string express, object[] args, string expected)
        {
            Assert.That(express.FormatWith(args), Is.EqualTo(expected));
        }
    }
}
