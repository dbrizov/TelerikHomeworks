using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseSequence
{
    public class ReverseSequenceMain
    {
        public static void PrintList<T>(List<T> list)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                result.Append(list[i] + " ");
            }

            Console.WriteLine(result.ToString());
        }

        public static void Main(string[] args)
        {
            Stack<int> sequence = new Stack<int>();
            string input = null;

            do
            {
                Console.Write("Enter an integer: ");
                int number = 0;
                input = Console.ReadLine();
                bool parsed = int.TryParse(input, out number);

                if (parsed)
                {
                    sequence.Push(number);
                }
            }
            while (input != string.Empty);

            List<int> reversed = new List<int>();
            while (sequence.Count > 0)
            {
                reversed.Add(sequence.Pop());
            }

            PrintList(reversed);
        }
    }
}
