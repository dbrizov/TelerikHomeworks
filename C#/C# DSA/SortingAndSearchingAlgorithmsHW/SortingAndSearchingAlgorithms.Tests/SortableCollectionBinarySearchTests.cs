using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingAlgorithms.Tests
{
    [TestClass]
    public class SortableCollectionBinarySearchTests
    {
        [TestMethod]
        public void BinarySearchSearch_LastItemFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = 0;
            int actual = collection.BinarySearch(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_FirstItemFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = 9;
            int actual = collection.BinarySearch(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_MiddleItemFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = 5;
            int actual = collection.BinarySearch(6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_ItemNotFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = -1;
            int actual = collection.BinarySearch(0);

            Assert.AreEqual(expected, actual);
        }
    }
}
