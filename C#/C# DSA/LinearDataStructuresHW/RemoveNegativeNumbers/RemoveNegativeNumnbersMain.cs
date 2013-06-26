using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativeNumbers
{
    public class RemoveNegativeNumnbersMain
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
            int[] arr = new int[] { 1, -1, 2, -2, 3, -3, 4, -4, 0 };
            List<int> sequence = new List<int>(arr);

            PrintList(sequence); // Print the original sequence
            sequence.RemoveAll(x => x < 0);
            PrintList(sequence); // Print the modified sequence
        }
    }
}
