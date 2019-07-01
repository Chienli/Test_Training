using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace XmasChecker.Tests
{
    [TestClass()]
    public class XmasCheckerTests
    {
        [TestMethod()]
        public void Today_is_not_xmas()
        {
            var dateTime = new DateTime(2011, 11, 25);
            var fakeXmasChecker = Substitute.For<XmasChecker>(dateTime);

            var actual = fakeXmasChecker.IsTodayXmas();

            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void Today_is_xmas()
        {
            var dateTime = new DateTime(2011, 12, 25);
            var fakeXmasChecker = Substitute.For<XmasChecker>(dateTime);

            var actual = fakeXmasChecker.IsTodayXmas();
            Assert.AreEqual(true, actual);
        }
    }
}