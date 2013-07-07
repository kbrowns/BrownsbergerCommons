using System;
using NUnit.Framework;

namespace Brownsberger.Commons.UnitTests
{
    [TestFixture]
    public class CheckFixture
    {
        [Test]
        public void CheckForNull_On_Null_Should_Throw_An_ArgumentNullException_By_Default()
        {
            Assert.Throws<NullReferenceException>(() => ((object)null).CheckForNull());
        }

        [Test]
        public void CheckForNull_On_Null_Should_Throw_An_Custom_Exception_When_Func_Is_Passed()
        {
            Assert.Throws<InvalidOperationException>(() => ((object)null).CheckForNull(() => new InvalidOperationException()));
        }

        [Test]
        public void CheckForNull_On_Not_Null_Should_Return_The_Passed_Parameter()
        {
            object thing = new object();

            Assert.That(thing, Is.SameAs(thing.CheckForNull()));
        }

        [Test]
        public void CheckForNullArg_On_Null_Should_Throw_An_ArgumentNullException_By_Default()
        {
            Assert.Throws<ArgumentNullException>(() => ((object)null).CheckForNullArg("foo"));
        }
    }
}