using Date.Net;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Date.Net.Tests
{
    [TestClass()]
    public class DateExtensionsTests
    {
        [TestMethod()]
        public void AgeTest()
        {
            Age age = new DateTime(1965, 8, 22).Age(referenceDate: new DateTime(2016, 4, 18));
            Assert.AreEqual(age.Years, 50);
            Assert.AreEqual(age.Months, 7);
        }

        [TestMethod()]
        public void FromYyyymmddTest()
        {
            DateTime date = new DateTime().FromYyyymmdd("1965-08-22");
            Assert.AreEqual(date.Year, 1965);
            Assert.AreEqual(date.Month, 8);
            Assert.AreEqual(date.Day, 22);
            date = date.FromYyyymmdd("2005/12/18");
            Assert.AreEqual(date.Year, 2005);
            Assert.AreEqual(date.Month, 12);
            Assert.AreEqual(date.Day, 18);
        }
    }
}
