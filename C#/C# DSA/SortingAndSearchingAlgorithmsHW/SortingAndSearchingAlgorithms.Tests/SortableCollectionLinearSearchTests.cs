using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingAlgorithms.Tests
{
    [TestClass]
    public class SortableCollectionLinearSearchTests
    {
        [TestMethod]
        public void LinearSearch_LastItemFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = 0;
            int actual = collection.LinearSearch(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinearSearch_FirstItemFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = 9;
            int actual = collection.LinearSearch(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinearSearch_MiddleItemFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = 5;
            int actual = collection.LinearSearch(6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinearSearch_ItemNotFound()
        {
            var collection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            int expected = -1;
            int actual = collection.LinearSearch(0);

            Assert.AreEqual(expected, actual);
        }
    }
}
