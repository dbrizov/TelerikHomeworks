using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueueWithBinaryHeap;
using System.Text;

namespace PriorityQueue.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestEnqueue_OneItem()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(1);

            Assert.AreEqual(1, priorityQueue.Count);
        }

        [TestMethod]
        public void TestEnqueue_100Item()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                priorityQueue.Enqueue(i);
            }

            Assert.AreEqual(100, priorityQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestDequeue_EmptyQueue()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Dequeue();
        }

        [TestMethod]
        public void TestDequeue_TenItems()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int items = 10;
            for (int i = 0; i < items; i++)
            {
                priorityQueue.Enqueue(i);
            }

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(priorityQueue.Dequeue());
            }

            string expected = "9876543210";

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
