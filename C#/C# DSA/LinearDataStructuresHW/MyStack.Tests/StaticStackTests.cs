using System;
using System.Text;
using MyStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyStack.Tests
{
    [TestClass]
    public class StaticStackTests
    {
        [TestMethod]
        public void TestPush_FiveItems()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(stackCount, stack.Count);
            Assert.AreEqual("43210", stack.ToString());
        }

        [TestMethod]
        public void TestPush_TenItems()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(stackCount, stack.Count);
            Assert.AreEqual("9876543210", stack.ToString());
        }

        [TestMethod]
        public void TestPeek_NonEmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(4, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();

            Assert.AreEqual(4, stack.Peek());
        }

        [TestMethod]
        public void TestPop_OneItem()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            int popped = stack.Pop();
            Assert.AreEqual(4, popped);
            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual("3210", stack.ToString());
        }

        [TestMethod]
        public void TestPop_MultipleItems()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 5; i++)
            {
                int popped = stack.Pop();
                Assert.AreEqual(9 - i, popped);
            }

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual("43210", stack.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPop_EmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();

            Assert.AreEqual(4, stack.Pop());
        }

        [TestMethod]
        public void TestToString_NonEmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();
            int stackCount = 10;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual("9876543210", stack.ToString());
        }

        [TestMethod]
        public void TestToString_EmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();

            Assert.AreEqual(string.Empty, stack.ToString());
        }

        [TestMethod]
        public void TestClone_EmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();
            StaticStack<int> clone = (StaticStack<int>)stack.Clone();

            int count = 5;
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual(0, clone.Count);
            Assert.AreEqual(string.Empty, clone.ToString());
        }

        [TestMethod]
        public void TestClone_NonEmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            StaticStack<int> clone = (StaticStack<int>)stack.Clone();

            for (int i = 0; i < stackCount; i++)
            {
                stack.Pop();
            }

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(5, clone.Count);
            Assert.AreEqual("43210", clone.ToString());
        }

        [TestMethod]
        public void TestClear_EmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(string.Empty, stack.ToString());
        }

        [TestMethod]
        public void TestClear_NonEmptyStack()
        {
            StaticStack<int> stack = new StaticStack<int>();
            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(string.Empty, stack.ToString());
        }

        [TestMethod]
        public void TestForeachLoop_Enumerator()
        {
            StaticStack<int> stack = new StaticStack<int>();

            int stackCount = 5;
            for (int i = 0; i < stackCount; i++)
            {
                stack.Push(i);
            }

            string expected = "43210";
            StringBuilder actual = new StringBuilder();

            foreach (var item in stack)
            {
                actual.Append(item.ToString());
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
