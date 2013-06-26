using System;
using System.Text;
using MyQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyQueue.Tests
{
    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void TestEnqueue_OneItem()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("1", queue.ToString());
        }

        [TestMethod]
        public void TestEnqueue_TenItems()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 10;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(queueCount, queue.Count);
            Assert.AreEqual("0123456789", queue.ToString());
        }

        [TestMethod]
        public void TestDequeue_OneItem()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 5;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            int dequeuedItem = queue.Dequeue();

            Assert.AreEqual(0, dequeuedItem);
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual("1234", queue.ToString());
        }

        [TestMethod]
        public void TestDequeue_MultipleItems()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 10;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 5; i++)
            {
                int dequeuedItem = queue.Dequeue();
                Assert.AreEqual(i, dequeuedItem);
            }

            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual("56789", queue.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeue_EmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Peek();
        }

        [TestMethod]
        public void TestPeek_NonEmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 5;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            int front = queue.Peek();

            Assert.AreEqual(0, front);
        }

        [TestMethod]
        public void TestToString_EmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            Assert.AreEqual(string.Empty, queue.ToString());
        }

        [TestMethod]
        public void TestToString_NonEmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 5;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual("01234", queue.ToString());
        }

        [TestMethod]
        public void TestToArray_EmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int[] arr = queue.ToArray();

            Assert.AreEqual(0, arr.Length);
        }

        [TestMethod]
        public void TestToArray_NonEmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 10;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            int[] arr = queue.ToArray();

            Assert.AreEqual(10, arr.Length);
            Assert.AreEqual(queue.Peek(), arr[0]);
            Assert.AreEqual(queue.ToString(), string.Join(string.Empty, arr));
        }

        [TestMethod]
        public void TestClear_NonEmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 10;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            queue.Clear();

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestClear_EmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Clear();

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestClone_EmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            LinkedQueue<int> clone = (LinkedQueue<int>)queue.Clone();

            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(0, clone.Count);
            Assert.AreEqual(5, queue.Count);
        }

        [TestMethod]
        public void TestClone_NonEmptyQueue()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 5;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            LinkedQueue<int> clone = (LinkedQueue<int>)queue.Clone();

            queue.Dequeue();

            Assert.AreEqual(5, clone.Count);
            Assert.AreEqual("01234", clone.ToString());
            Assert.AreEqual(4, queue.Count);
        }

        [TestMethod]
        public void TestForeachLoop_Enumerator()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            int queueCount = 5;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            string expected = "01234";
            StringBuilder actual = new StringBuilder();

            foreach (var item in queue)
            {
                actual.Append(item.ToString());
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
