using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetUtility;

namespace DotNetutilityTest
{
    /// <summary>
    /// Test DateTimeExtensions
    /// </summary>
    [TestClass]
    public class TestDateTimeExtensions
    {
        /// <summary>
        /// Test GetTimeZone
        /// </summary>
        [TestMethod]
        public void TestGetTimeZone()
        {
            Assert.AreEqual(DateTime.Now, DateTimeExtensions.GetTimeZone(DotNetUtility.TimeZone.Local));
            Assert.AreEqual(DateTime.UtcNow, DateTimeExtensions.GetTimeZone(DotNetUtility.TimeZone.Utc));
        }

        /// <summary>
        /// Test GetAge
        /// </summary>
        [TestMethod]
        public void TestGetAge()
        {
            var dt = new DateTime(2000, 2, 1);

            Assert.AreEqual(16, dt.GetAge(new DateTime(2016, 12, 31)));
            Assert.AreEqual(16, dt.GetAge(new DateTime(2017, 1, 1)));
            Assert.AreEqual(16, dt.GetAge(new DateTime(2017, 1, 31)));
            Assert.AreEqual(17, dt.GetAge(new DateTime(2017, 2, 1)));
            Assert.AreEqual(17, dt.GetAge(new DateTime(2017, 2, 28)));
            Assert.AreEqual(17, dt.GetAge(new DateTime(2017, 3, 1)));
        }

        /// <summary>
        /// Test ToInt
        /// </summary>
        [TestMethod]
        public void TestToInt()
        {
            var dtCase1 = new DateTime(2000, 1, 1);
            var dtCase2 = new DateTime(2000, 10, 1);
            var dtCase3 = new DateTime(2000, 1, 10);
            var dtCase4 = new DateTime(2000, 10, 10);

            Assert.AreEqual(20000101, dtCase1.ToInt());
            Assert.AreEqual(20001001, dtCase2.ToInt());
            Assert.AreEqual(20000110, dtCase3.ToInt());
            Assert.AreEqual(20001010, dtCase4.ToInt());
        }

        /// <summary>
        /// Test MothLastDay
        /// </summary>
        [TestMethod]
        public void TestMonthLastDay()
        {
            var dtCase1 = new DateTime(2000, 1, 1);
            var dtCase2 = new DateTime(2000, 12, 31);

            Assert.AreEqual(new DateTime(2000, 1, 31), dtCase1.MonthLastDay());
            Assert.AreEqual(new DateTime(2000, 12, 31), dtCase1.MonthLastDay());
            
        }
    }
}
