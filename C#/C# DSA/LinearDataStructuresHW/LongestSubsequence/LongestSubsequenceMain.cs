using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestSubsequence
{
    public class LongestSubsequenceMain
    {
        public static string GetAsString<T>(List<T> list)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                result.Append(list[i] + " ");
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns the longest subsequence of consecutive elements in a given sequence
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence</typeparam>
        /// <param name="sequence">The sequence</param>
        /// <returns>
        /// Returnes the longest subsequence as List. If the are more than 1 longest
        /// subsequences (they have equal length),
        /// then only the first longest subsequence is returned
        /// </returns>
        public static List<T> GetLongestConsecutiveSubsequence<T>(List<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("The sequence is null");
            }

            if (sequence.Count == 0)
            {
                throw new ArgumentException("The sequence is empty");
            }

            T previousElement = sequence[0];
            int count = 1;
            int maxCount = 1;
            T longestSequenceConstructElement = previousElement;

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i].Equals(previousElement))
                {
                    count++;

                    if (maxCount < count)
                    {
                        maxCount = count;
                        longestSequenceConstructElement = previousElement;
                    }
                }
                else
                {
                    count = 1;
                }

                previousElement = sequence[i];
            }

            List<T> longestSubsequence = new List<T>();
            for (int i = 0; i < maxCount; i++)
            {
                longestSubsequence.Add(longestSequenceConstructElement);
            }

            return longestSubsequence;
        }

        public static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            string input = null;

            do
            {
                Console.Write("Enter an integer: ");
                int number = 0;
                input = Console.ReadLine();
                bool parsed = int.TryParse(input, out number);

                if (parsed)
                {
                    sequence.Add(number);
                }
            }
            while (input != string.Empty);

            List<int> subsequence = GetLongestConsecutiveSubsequence(sequence);

            Console.WriteLine("sequence -> {0}", GetAsString(sequence));
            Console.WriteLine("subsequence -> {0}", GetAsString(subsequence));
        }
    }
}
