using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace HashedSet.Tests
{
    [TestClass]
    public class HashedSetTests
    {
        [TestMethod]
        public void TestAdd_OneItem()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 1;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            Assert.AreEqual(itemsCount, set.Count);
        }

        [TestMethod]
        public void TestAdd_50000Items()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 50000;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            Assert.AreEqual(itemsCount, set.Count);
        }

        [TestMethod]
        public void TestRemove_Success()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 100;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            bool removed = set.Remove(5);
            Assert.AreEqual(true, removed);
            Assert.AreEqual(99, set.Count);
            Assert.IsFalse(set.Contains(5));
        }

        [TestMethod]
        public void TestRemove_Fail()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 100;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            bool removed = set.Remove(100);
            Assert.AreEqual(false, removed);
            Assert.AreEqual(100, set.Count);
            Assert.IsTrue(set.Contains(5));
        }

        [TestMethod]
        public void TestContains()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 100;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(99));
            Assert.IsTrue(set.Contains(28));
            Assert.IsFalse(set.Contains(-1));
            Assert.IsFalse(set.Contains(120));
        }

        [TestMethod]
        public void TestClear()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 100;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            Assert.AreEqual(100, set.Count);
            Assert.IsTrue(set.Contains(5));

            set.Clear();
            Assert.AreEqual(0, set.Count);
            Assert.IsFalse(set.Contains(5));
        }

        [TestMethod]
        public void TestUnionWith_SecondSetIsEmpty()
        {
            MyHashSet<int> firstSet = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                firstSet.Add(i);
            }

            MyHashSet<int> secondSet = new MyHashSet<int>();

            firstSet.UnionWith(secondSet);

            Assert.AreEqual(5, firstSet.Count);
        }

        [TestMethod]
        public void TestUnionWith_FirstSetIsEmpty()
        {
            MyHashSet<int> firstSet = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                firstSet.Add(i);
            }

            MyHashSet<int> secondSet = new MyHashSet<int>();

            secondSet.UnionWith(firstSet);

            Assert.AreEqual(5, secondSet.Count);
        }

        [TestMethod]
        public void TestUnionWith_BothArentEmpty()
        {
            MyHashSet<int> firstSet = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                firstSet.Add(i);
            }

            MyHashSet<int> secondSet = new MyHashSet<int>();
            for (int i = 3; i < 7; i++)
            {
                secondSet.Add(i);
            }

            // 0,1,2,3,4 U 3,4,5,6 = 0,1,2,3,4,5,6
            firstSet.UnionWith(secondSet);

            Assert.AreEqual(7, firstSet.Count);
            Assert.IsTrue(firstSet.Contains(0));
            Assert.IsTrue(firstSet.Contains(1));
            Assert.IsTrue(firstSet.Contains(2));
            Assert.IsTrue(firstSet.Contains(3));
            Assert.IsTrue(firstSet.Contains(4));
            Assert.IsTrue(firstSet.Contains(5));
            Assert.IsTrue(firstSet.Contains(6));
        }

        [TestMethod]
        public void TestIntersectWith_SecondSetIsEmpty()
        {
            MyHashSet<int> firstSet = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                firstSet.Add(i);
            }

            MyHashSet<int> secondSet = new MyHashSet<int>();

            firstSet.IntersectWith(secondSet);

            Assert.AreEqual(0, firstSet.Count);
        }

        [TestMethod]
        public void TestIntersectWith_FirstSetIsEmpty()
        {
            MyHashSet<int> firstSet = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                firstSet.Add(i);
            }

            MyHashSet<int> secondSet = new MyHashSet<int>();

            secondSet.IntersectWith(firstSet);

            Assert.AreEqual(0, secondSet.Count);
        }

        [TestMethod]
        public void TestIntersectWith_BothArentEmpty()
        {
            MyHashSet<int> firstSet = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                firstSet.Add(i);
            }

            MyHashSet<int> secondSet = new MyHashSet<int>();
            for (int i = 3; i < 7; i++)
            {
                secondSet.Add(i);
            }

            // 0,1,2,3,4 ^ 3,4,5,6 = 3,4
            firstSet.IntersectWith(secondSet);

            Assert.AreEqual(2, firstSet.Count);
            Assert.IsTrue(firstSet.Contains(3));
            Assert.IsTrue(firstSet.Contains(4));
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            MyHashSet<int> set = new MyHashSet<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                set.Add(i);
            }

            List<int> items = new List<int>();
            foreach (var item in set)
            {
                items.Add(item);
            }

            items.Sort();

            string expected = "01234";
            StringBuilder actual = new StringBuilder();
            foreach (var item in items)
            {
                actual.Append(item);
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
