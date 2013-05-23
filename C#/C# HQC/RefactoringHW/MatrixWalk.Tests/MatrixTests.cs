using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixWalk.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestToString_Matrix3x3()
        {
            WalkedMatrix matrix = new WalkedMatrix(3, 3);
            StreamReader reader = new StreamReader("test-3x3.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix4x4()
        {
            WalkedMatrix matrix = new WalkedMatrix(4, 4);
            StreamReader reader = new StreamReader("test-4x4.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix5x5()
        {
            WalkedMatrix matrix = new WalkedMatrix(5, 5);
            StreamReader reader = new StreamReader("test-5x5.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix6x6()
        {
            WalkedMatrix matrix = new WalkedMatrix(6, 6);
            StreamReader reader = new StreamReader("test-6x6.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix7x7()
        {
            WalkedMatrix matrix = new WalkedMatrix(7, 7);
            StreamReader reader = new StreamReader("test-7x7.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix8x8()
        {
            WalkedMatrix matrix = new WalkedMatrix(8, 8);
            StreamReader reader = new StreamReader("test-8x8.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix9x9()
        {
            WalkedMatrix matrix = new WalkedMatrix(9, 9);
            StreamReader reader = new StreamReader("test-9x9.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix10x10()
        {
            WalkedMatrix matrix = new WalkedMatrix(10, 10);
            StreamReader reader = new StreamReader("test-10x10.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_Matrix15x15()
        {
            WalkedMatrix matrix = new WalkedMatrix(15, 15);
            StreamReader reader = new StreamReader("test-15x15.txt");
            string actual = matrix.ToString();
            string expected;

            using (reader)
            {
                expected = reader.ReadToEnd();
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
