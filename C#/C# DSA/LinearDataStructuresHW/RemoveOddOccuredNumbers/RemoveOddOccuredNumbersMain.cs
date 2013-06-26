using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveOddOccuredNumbers
{
    public class RemoveOddOccuredNumbersMain
    {
        public static void PrintList(List<int> list)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                result.Append(list[i] + " ");
            }

            Console.WriteLine(result.ToString());
        }

        public static void RemoveOddOccuredItems(List<int> list)
        {
            int maxElement = list.Max();

            // Element 5 is at index 5 and the value of the cell is the number of occurences.
            // That's done for all of the elements in array.
            // maxElement is needed because this way I know how big the array with the
            // occurences need to be. If we have an element with value 1002 then
            // the array's length must be 1003. This way the number of occurences of element
            // 1002 is is elementsCount[1002] where elementsCounts is the array with the
            // number of occurences of each element in array.
            int[] elementsOcurrences = new int[maxElement + 1];
            for (int i = 0; i < list.Count; i++)
            {
                int elementIndex = list[i];
                elementsOcurrences[elementIndex]++;
            }

            // Remove the elements that occur odd number of times
            for (int i = 0; i < elementsOcurrences.Length; i++)
            {
                if (elementsOcurrences[i] % 2 != 0)
                {
                    list.RemoveAll(x => x == i);
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> sequence = new List<int>(arr);

            PrintList(sequence); // Print the original sequence
            RemoveOddOccuredItems(sequence);
            PrintList(sequence); // Print the modified sequence
        }
    }
}
