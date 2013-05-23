using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsPerformance
{
    public static class QuickSort
    {
        private static int Partition<T>(T[] arr, int leftIndex, int rightIndex, int pivotIndex)
            where T : IComparable
        {
            T pivotValue = arr[pivotIndex];

            T temp = arr[rightIndex];
            arr[rightIndex] = arr[pivotIndex];
            arr[pivotIndex] = temp;

            int storeIndex = leftIndex;

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                if (arr[i].CompareTo(pivotValue) < 0)
                {
                    temp = arr[i];
                    arr[i] = arr[storeIndex];
                    arr[storeIndex] = temp;

                    storeIndex++;
                }
            }

            temp = arr[storeIndex];
            arr[storeIndex] = arr[rightIndex];
            arr[rightIndex] = temp;

            return storeIndex;
        }

        private static void Sort<T>(T[] arr, int leftIndex, int rightIndex)
            where T : IComparable
        {
            if (rightIndex - leftIndex < 1)
            {
                return;
            }

            int pivotIndex = (rightIndex + leftIndex) / 2;

            int pivotFinalPositionIndex = Partition<T>(arr, leftIndex, rightIndex, pivotIndex);

            Sort<T>(arr, leftIndex, pivotFinalPositionIndex - 1);

            Sort<T>(arr, pivotFinalPositionIndex + 1, rightIndex);
        }

        public static void Sort<T>(T[] arr)
            where T : IComparable
        {
            Sort<T>(arr, 0, arr.Length - 1);
        }
    }
}
