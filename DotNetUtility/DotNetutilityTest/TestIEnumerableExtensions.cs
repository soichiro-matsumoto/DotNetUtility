using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DotNetUtility;

namespace DotNetutilityTest
{
    /// <summary>
    /// Test IEnumerableExtensions
    /// </summary>
    [TestClass]
    public class TestIEnumerableExtensions
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
        /// Test IsNullOrEmpty
        /// </summary>
        [TestMethod]
        public void TestIsNullOrEmpty()
        {
            MockClass[] aryEmpty = new List<MockClass>().ToArray();
            MockClass[] aryNull = null;

            MockClass[] ary = new List<MockClass>()
            {
                new MockClass() { IntProp = 1, StrProp = "test" },
                new MockClass() { IntProp = 2, StrProp = "test" },
                new MockClass() { IntProp = 3, StrProp = "test" }
            }.ToArray();

            //// 0件の検証
            Assert.IsTrue(aryEmpty.IsNullOrEmpty());

            //// Nullの検証
            Assert.IsTrue(aryNull.IsNullOrEmpty());

            //// 要素が1件以上格納存在する検証
            Assert.IsFalse(ary.IsNullOrEmpty());
        }

        /// <summary>
        /// Test Next
        /// </summary>
        [TestMethod]
        public void TestNext()
        {
            List<MockClass> list = new List<MockClass>()
            {
                new MockClass() { IntProp = 1, StrProp = "test" },
                new MockClass() { IntProp = 2, StrProp = "test" },
                new MockClass() { IntProp = 3, StrProp = "test" }
            };

            var first = list[0];
            var second = list[1];
            var last = list[2];

            var not = new MockClass() { IntProp = 0, StrProp = "test" };

            //// 次の要素との検証
            Assert.AreEqual(second, list.Next(first));
            Assert.AreEqual(last, list.Next(second));

            //// 最後の要素なので、nullを返す
            Assert.AreEqual(null, list.Next(last));

            //// リストに存在しない要素なので、nullを返す
            Assert.AreEqual(null, list.Next(not));
        }

        /// <summary>
        /// Test Prev
        /// </summary>
        [TestMethod]
        public void TestPrev()
        {
            List<MockClass> list = new List<MockClass>()
            {
                new MockClass() { IntProp = 1, StrProp = "test" },
                new MockClass() { IntProp = 2, StrProp = "test" },
                new MockClass() { IntProp = 3, StrProp = "test" }
            };

            var first = list[0];
            var second = list[1];
            var last = list[2];

            var not = new MockClass() { IntProp = 0, StrProp = "test" };

            //// 最初の要素なので、nullを返す
            Assert.AreEqual(null, list.Prev(first));

            //// 前の要素との検証
            Assert.AreEqual(first, list.Prev(second));
            Assert.AreEqual(second, list.Prev(last));

            //// リストに存在しない要素なので、nullを返す
            Assert.AreEqual(null, list.Prev(not));
        }
    }
}
