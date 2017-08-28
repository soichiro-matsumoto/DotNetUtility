using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetUtility;

namespace DotNetutilityTest
{
    [TestClass]
    public class TestObjectExtensions
    {
        /// <summary>
        /// TestClass
        /// </summary>
        class MockClass
        {
            /// <summary>
            /// String Properties
            /// </summary>
            public string StrProp { get; set; }

            /// <summary>
            /// Int Properties
            /// </summary>
            public int IntProp { get; set; }
        }

        /// <summary>
        /// Test IsNull
        /// </summary>
        [TestMethod]
        public void TestIsNull()
        {
            MockClass @object = new MockClass() { IntProp = 1, StrProp = "test" };
            MockClass @null = null;

            Assert.IsFalse(@object.IsNull());
            Assert.IsTrue(@null.IsNull());
        }

        /// <summary>
        /// Test ToNonNullable
        /// </summary>
        [TestMethod]
        public void TestToNonNullable()
        {
            int? intNull1 = 100;
            int? intNull2 = null;

            Assert.AreEqual(typeof(int), intNull1.ToNonNullable().GetType());
            Assert.AreEqual(typeof(int), intNull2.ToNonNullable().GetType());

            Assert.AreEqual(100, intNull1.ToNonNullable());
            Assert.AreEqual(default(int), intNull2.ToNonNullable());
        }

        /// <summary>
        /// Test ToNullable
        /// </summary>
        [TestMethod]
        public void TestToNullable()
        {
            int @int = 100;
            int? intNull = @int.ToNullable();
        }
    }
}
