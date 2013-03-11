using System;

class QuickSort
{
    // Divides a given array into two partitions (with smallest and with biggest elements)
    private static int partition(int[] array, int leftIndex, int rightIndex, int pivotIndex)
    {
        // leftIndex is the index of the leftmost element in the array
        // rightIndex is the index of the rightmost element in the array
        // pivotIndex is the index of a random element in the array
        int pivotValue = array[pivotIndex];

        // Swap array[pivotIndex] and array[rightIndex] (move pivot to end)
        int temp = pivotValue;
        array[pivotIndex] = array[rightIndex];
        array[rightIndex] = temp;

        int storeIndex = leftIndex; // Helper index for the partition

        // Partition the array
        for (int i = leftIndex; i < rightIndex; i++)
        {
            if (array[i] < pivotValue)
            {
                // Swap array[i] and array[storeIndex]
                temp = array[i];
                array[i] = array[storeIndex];
                array[storeIndex] = temp;
                storeIndex++;
            }
        }

        // Swap array[storeIndex] and array[rightIndex]
        // (move pivot to it's final place - between the less and the greater elements)
        temp = array[storeIndex];
        array[storeIndex] = array[rightIndex];
        array[rightIndex] = temp;

        return storeIndex; // return the index of the pivots position
    }

    // Private quickSort algorithm function
    private static void quickSort(int[] array, int leftIndex, int rightIndex)
    {
        if (rightIndex - leftIndex >= 1) // If there are 2 or more elements in the array
        {
            Random randomIndex = new Random();
            // pivotIndex = [leftIndex, rightIndex]
            int pivotIndex = randomIndex.Next(rightIndex - leftIndex + 1) + leftIndex;

            // Get the left and right subarrays
            int pivotNextIndex = partition(array, leftIndex, rightIndex, pivotIndex);

            // Recursively sort elements smaller than the pivot (left of the pivot)
            quickSort(array, leftIndex, pivotNextIndex - 1);
            // Recursively sort elements bigger than the pivot (right of the pivot)
            quickSort(array, pivotNextIndex + 1, rightIndex);
        }
    }

    // Public quickSort function that calls the private quickSort function
    // There are two separate functions, because that way it's easier for the user to use quickSort
    public static void quickSort(int[] array)
    {
        quickSort(array, 0, array.Length - 1);
    }

    static void Main(string[] args)
    {
        int[] array;
        int arrayLength;

        Console.Write("Array length = ");
        arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        quickSort(array);

        // Print the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}