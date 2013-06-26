using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheMajorant
{
    public class FindTheMajorantMain
    {
        public static bool FindMajorant(int[] array, out int majorant)
        {
            int maxElement = array.Max();

            // Element 5 is at index 5 and the value of the cell is the number of occurences.
            // That's done for all of the elements in array.
            // maxElement is needed because this way I know how big the array with the
            // occurences need to be. If we have an element with value 1002 then
            // the array's length must be 1003. This way the number of occurences of element
            // 1002 is is elementsCount[1002] where elementsCounts is the array with the
            // number of occurences of each element in array.
            int[] elementsCounts = new int[maxElement + 1];
            for (int i = 0; i < array.Length; i++)
            {
                int elementIndex = array[i];
                elementsCounts[elementIndex]++;
            }

            // Find the element that occures the most
            int maxElementCount = int.MinValue;
            int mostOccuredElement = 0;
            for (int i = 0; i < elementsCounts.Length; i++)
            {
                if (maxElementCount < elementsCounts[i])
                {
                    maxElementCount = elementsCounts[i];
                    mostOccuredElement = i;
                }
            }

            // Check if the most occured element is a majorant
            bool found = false;
            majorant = 0;
            if (maxElementCount >= array.Length / 2 + 1)
            {
                found = true;
                majorant = mostOccuredElement;
            }

            return found;
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            //int[] arr = new int[] { 2, 2, 3, 3, 2, 3, 4, 3 }; // here there is no majorant

            int majorant;
            bool found = FindMajorant(arr, out majorant);

            Console.WriteLine("found: {0}", found);
            if (found)
            {
                Console.WriteLine("majorant: {0}", majorant);
            }
        }
    }
}
