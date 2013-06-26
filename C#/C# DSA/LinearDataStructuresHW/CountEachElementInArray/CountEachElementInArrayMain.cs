using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountEachElementInArray
{
    public class CountEachElementInArrayMain
    {
        public static void CountEachElement(int[] array)
        {
            int maxElement = array.Max();
            int minElement = array.Min();

            if (maxElement > 1000 || minElement < 0)
            {
                throw new ArgumentException("The array has an element that is not in range [0, 1000]");
            }

            // Element 5 is at index 5 and the value of the cell is the number of occurences.
            // That's done for all of the elements in array
            // For example: the counts of element 7 is the value ot elementsCounts[7],
            // where elementsCounts is the array with the
            // number of occurences of each element in array.
            int[] elementsCounts = new int[1001];
            for (int i = 0; i < array.Length; i++)
            {
                int elementIndex = array[i];
                elementsCounts[elementIndex]++;
            }

            // Display the counts
            for (int i = 0; i < elementsCounts.Length; i++)
            {
                if (elementsCounts[i] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", i, elementsCounts[i]);
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 1000, 1, 1, 2, 2, 2, 0, 3, 3, 3, 3, 1000, 0, 0, 0, 0 };
            //int[] arr = new int[] { 1001, 1, 1, 2, 2, 2, 0, 3, 3, 3, 3, 1000, 0, 0, 0, 0 }; // This array throws an exception - 1001 is not in range [0, 1000]
            //int[] arr = new int[] { -1, 1, 1, 2, 2, 2, 0, 3, 3, 3, 3, 1000, 0, 0, 0, 0 }; // This array throws an exception - (-1) is not in range [0, 1000]

            Console.WriteLine(string.Join(", ", arr));
            CountEachElement(arr);
        }
    }
}
