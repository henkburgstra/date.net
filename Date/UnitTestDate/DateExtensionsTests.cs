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
    }
}
