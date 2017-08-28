using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetUtility.Attribute;

namespace DotNetutilityTest
{
    /// <summary>
    /// Test ExDisplayNameAttribute
    /// </summary>
    [TestClass]
    public class TestExDisplayNameAttribute
    {
        /// <summary>
        /// Mock Enum
        /// </summary>
        enum MockEnum
        {
            [ExDisplayName("String_Mock1")]
            Mock1,
            [ExDisplayName("String_Mock2")]
            Mock2,
            Mock3,
        }

        /// <summary>
        /// Test DisplayName
        /// </summary>
        [TestMethod]
        public void TestDsiplayName()
        {
            Assert.AreEqual("String_Mock1", MockEnum.Mock1.DisplayName());
            Assert.AreEqual("String_Mock2", MockEnum.Mock2.DisplayName());
            Assert.AreEqual(null, MockEnum.Mock3.DisplayName());
        }
    }
}
