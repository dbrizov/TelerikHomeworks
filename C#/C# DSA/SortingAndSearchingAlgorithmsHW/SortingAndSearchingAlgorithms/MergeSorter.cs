namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private static void MergeSort(IList<T> collection)
        {
            // If the array has less then 2 elements the function is returned
            if (collection.Count < 2)
            {
                return;
            }

            // Generate two partition arrays
            List<T> leftCollection = new List<T>(collection.Count / 2);
            List<T> rightCollection = new List<T>(collection.Count - leftCollection.Capacity);
            int leftCollectionCapacity = leftCollection.Capacity;

            for (int i = 0; i < leftCollectionCapacity; i++)
            {
                leftCollection.Add(collection[i]);
            }

            for (int i = leftCollectionCapacity; i < collection.Count; i++)
            {
                rightCollection.Add(collection[i]);
            }

            // Recursively merge-sorts the leftCollection
            MergeSort(leftCollection);
            // Recursively merge-sorts the rightCollection
            MergeSort(rightCollection);

            // Helper-array(the result from the merge of leftArray and rightArray)
            IList<T> result = Merge(leftCollection, rightCollection);
            // Overwrite the main array elements
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = result[i];
            }
        }

        private static IList<T> Merge(IList<T> firstList, IList<T> secondList)
        {
            IList<T> result = new List<T>(firstList.Count + secondList.Count);
            int firstListIndex = 0; // The index that will walkthrough the firstList
            int secondListIndex = 0; // The index that wll walkthrough the secondList

            while (firstListIndex < firstList.Count || secondListIndex < secondList.Count)
            {
                if (firstListIndex < firstList.Count && secondListIndex < secondList.Count)
                {
                    if (firstList[firstListIndex].CompareTo(secondList[secondListIndex]) < 0)
                    {
                        result.Add(firstList[firstListIndex]);
                        firstListIndex++;
                    }
                    else
                    {
                        result.Add(secondList[secondListIndex]);
                        secondListIndex++;
                    }
                }
                else if (firstListIndex < firstList.Count && secondListIndex == secondList.Count)
                {
                    result.Add(firstList[firstListIndex]);
                    firstListIndex++;
                }
                else if (firstListIndex == firstList.Count && secondListIndex < secondList.Count)
                {
                    result.Add(secondList[secondListIndex]);
                    secondListIndex++;
                }
            }

            return result;
        }
    }
}
