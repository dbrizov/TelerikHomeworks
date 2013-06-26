using System;
using System.Collections.Generic;
using LongestSubsequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace LongestSubsequence.Tests
{
    [TestClass]
    public class LongestSubsequenceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetLongestConsecutiveSubsequence_NullList()
        {
            List<int> sequence = null;
            LongestSubsequenceMain.GetLongestConsecutiveSubsequence(sequence);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetLongestConsecutiveSubsequence_EmptyList()
        {
            List<int> sequence = new List<int>();
            LongestSubsequenceMain.GetLongestConsecutiveSubsequence(sequence);
        }

        [TestMethod]
        public void TestGetLongestConsecutiveSubsequence_OnlyOneElement()
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);

            List<int> subsequence = LongestSubsequenceMain.GetLongestConsecutiveSubsequence(sequence);

            Assert.AreEqual("1", LongestSubsequenceMain.GetAsString(subsequence).Trim());
        }

        [TestMethod]
        public void TestGetLongestConsecutiveSubsequence_TwoLongestSubsequences()
        {
            int[] arr = new int[] { 1, 1, 1, 2, 2, 3, 3, 3 };
            List<int> sequence = new List<int>(arr);

            List<int> subsequence = LongestSubsequenceMain.GetLongestConsecutiveSubsequence(sequence);

            Assert.AreEqual("1 1 1", LongestSubsequenceMain.GetAsString(subsequence).Trim());
        }

        [TestMethod]
        public void TestGetLongestConsecutiveSubsequence_OnlyOneLongestSubsequence()
        {
            int[] arr = new int[] { 1, 2, 2, 3, 3, 4, 4, 4, 5, 5 };
            List<int> sequence = new List<int>(arr);

            List<int> subsequence = LongestSubsequenceMain.GetLongestConsecutiveSubsequence(sequence);

            Assert.AreEqual("4 4 4", LongestSubsequenceMain.GetAsString(subsequence).Trim());
        }

        [TestMethod]
        public void TestGetLongestConsecutiveSubsequence_TheWholeSequenceIsTheLongestOne()
        {
            int[] arr = new int[] { 1, 1, 1, 1, 1 };
            List<int> sequence = new List<int>(arr);

            List<int> subsequence = LongestSubsequenceMain.GetLongestConsecutiveSubsequence(sequence);

            Assert.AreEqual("1 1 1 1 1", LongestSubsequenceMain.GetAsString(subsequence).Trim());
        }
    }
}
