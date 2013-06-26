using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingAlgorithms.Tests
{
    [TestClass]
    public class QuicksorterTests
    {
        [TestMethod]
        public void SortEmptyCollection()
        {
            var collection = new SortableCollection<int>(new int[0]);
            collection.Sort(new Quicksorter<int>());

            string expected = "";
            string actual = collection.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortCollection_OneItem()
        {
            var collection = new SortableCollection<int>(new int[] { 1 });
            collection.Sort(new Quicksorter<int>());

            string expected = "1";
            string actual = collection.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortCollection_EvenItems()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 10, 2, 9, 3, 8, 4, 7, 6, 5 });
            collection.Sort(new Quicksorter<int>());

            string expected = "1 2 3 4 5 6 7 8 9 10";
            string actual = collection.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortCollection_OddItems()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 10, 2, 9, 3, 8, 11, 4, 7, 6, 5 });
            collection.Sort(new Quicksorter<int>());

            string expected = "1 2 3 4 5 6 7 8 9 10 11";
            string actual = collection.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
