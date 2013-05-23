using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsPerformance
{
    public static class InsertionSort
    {
        public static void Sort<T>(T[] arr)
            where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T valueToInsert = arr[i];
                int holePosition = i;

                while (holePosition > 0 &&
                       valueToInsert.CompareTo(arr[holePosition - 1]) < 0)
                {
                    arr[holePosition] = arr[holePosition - 1];
                    holePosition--;
                }

                arr[holePosition] = valueToInsert;
            }
        }
    }
}
