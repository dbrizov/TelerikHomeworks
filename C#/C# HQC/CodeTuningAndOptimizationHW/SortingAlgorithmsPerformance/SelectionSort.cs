using System;

namespace SortingAlgorithmsPerformance
{
    public static class SelectionSort
    {
        public static void Sort<T>(T[] arr)
            where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[minElementIndex]) < 0)
                    {
                        minElementIndex = j;
                    }
                }

                T oldValue = arr[i];
                arr[i] = arr[minElementIndex];
                arr[minElementIndex] = oldValue;
            }
        }
    }
}
