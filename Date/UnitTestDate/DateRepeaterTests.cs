using Date.Net;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Date.Net.Tests
{
    [TestClass()]
    public class DateRepeaterTests
    {
        [TestMethod()]
        public void ContainsTest()
        {
            DateRepeater dr = new DateRepeater(Interval.DAILY, end: DateTime.Today.AddWeeks(2));
            var compare = DateTime.Today.AddWeeks(1);
            Assert.AreEqual(true, dr.Contains(compare));
        }
    }
}
