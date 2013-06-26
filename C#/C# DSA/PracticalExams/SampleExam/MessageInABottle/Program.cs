using System;
using System.Collections.Generic;
using System.Text;

namespace MessageInABottle
{
    class Program
    {
        static string message;
        static string cipher;
        static List<KeyValuePair<char, string>> pairs;
        static StringBuilder solution;
        static List<string> solutions;

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            cipher = Console.ReadLine();
            pairs = new List<KeyValuePair<char, string>>();
            solution = new StringBuilder();
            solutions = new List<string>();

            StringBuilder value = new StringBuilder();
            char key = '\0';
            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (value.Length != 0)
                    {
                        pairs.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }

                    key = cipher[i];
                }
                else
                {
                    value.Append(cipher[i]);
                }
            }

            if (value.Length != 0)
            {
                pairs.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(0, 0);

            Console.WriteLine(solutions.Count);
            solutions.Sort();
            foreach (var sol in solutions)
            {
                Console.WriteLine(sol);
            }

        }

        static void Solve(int messageIndex, int solutionIndex)
        {
            if (messageIndex == message.Length)
            {
                solutions.Add(solution.ToString());
                return;
            }
            else
            {
                foreach (var pair in pairs)
                {
                    if (message.Substring(messageIndex).StartsWith(pair.Value))
                    {
                        solution.Append(pair.Key);
                        Solve(messageIndex + pair.Value.Length, solutionIndex + 1);
                        solution.Remove(solution.Length - 1, 1);
                    }
                }
            }
        }
    }
}
