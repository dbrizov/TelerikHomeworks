namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        // I know there is repeating code, I wanted to make it inline,
        // because the sorting algorithm must be very fast.
        private static int Partition(IList<T> collection, int leftIndex, int rightIndex, int pivotIndex)
        {
            T pivotValue = collection[pivotIndex];

            // Swap collection[pivotIndex] and collection[rightIndex];
            T temp = collection[pivotIndex];
            collection[pivotIndex] = collection[rightIndex];
            collection[rightIndex] = temp;

            int storeIndex = leftIndex;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (collection[i].CompareTo(pivotValue) < 0)
                {
                    // Swap collection[storeIndex] and collection[i];
                    temp = collection[storeIndex];
                    collection[storeIndex] = collection[i];
                    collection[i] = temp;

                    storeIndex++;
                }
            }

            // Swap collection[storeIndex] and collection[rightIndex]
            temp = collection[storeIndex];
            collection[storeIndex] = collection[rightIndex];
            collection[rightIndex] = temp;

            return storeIndex;
        }

        private static void QuickSort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (rightIndex - leftIndex > 0)
            {
                int pivotIndex = (rightIndex + leftIndex) / 2;

                // The index that separates the subarrays(with lesser and with greates values than the pivot);
                int separatorIndex = Partition(collection, leftIndex, rightIndex, pivotIndex);

                // Recursively sort the left subarray
                QuickSort(collection, leftIndex, separatorIndex - 1);
                // Recursively sort the right subarray
                QuickSort(collection, separatorIndex + 1, rightIndex);
            }
        }
    }
}
