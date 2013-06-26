using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegerSequenceList
{
    public class IntegerSequenceMain
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
            List<int> sequence = new List<int>();
            string input = null;

            do
            {
                Console.Write("Enter a positive integer: ");
                int number = 0;
                input = Console.ReadLine();
                bool parsed = int.TryParse(input, out number);

                if (parsed && number > 0)
                {
                    sequence.Add(number);
                }
            }
            while (input != string.Empty);

            PrintList(sequence);
            Console.WriteLine("Sum = " + sequence.Sum());
            Console.WriteLine("Average = " + sequence.Average());
        }
    }
}
