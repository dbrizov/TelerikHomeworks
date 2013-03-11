using System;

class MergeSort
{
    // merge algorithmn (merges 2 sorted arrays)
    private static int[] merge(int[] arr1, int[] arr2)
    {
        int[] merged = new int[arr1.Length + arr2.Length]; // merged-array
        int mergedIndex = 0; // Index for the merged-array
        int index1 = 0; // Index for arr1(array1)
        int index2 = 0; // Index for arr2(array2)

        // The algorithmn
        while (index1 < arr1.Length || index2 < arr2.Length)
        {
            if (index1 < arr1.Length && index2 < arr2.Length)
            {
                if (arr1[index1] < arr2[index2])
                {
                    merged[mergedIndex] = arr1[index1];
                    mergedIndex++;
                    index1++;
                }
                else
                {
                    merged[mergedIndex] = arr2[index2];
                    mergedIndex++;
                    index2++;
                }
            }
            else if (index1 >= arr1.Length && index2 < arr2.Length)
            {
                merged[mergedIndex] = arr2[index2];
                mergedIndex++;
                index2++;
            }
            else if (index1 < arr1.Length && index2 >= arr2.Length)
            {
                merged[mergedIndex] = arr1[index1];
                mergedIndex++;
                index1++;
            }
        }

        return merged;
    }

    public static void mergeSort(int[] array)
    {
        // If the array has less then 2 elements the function is returned
        if (array.Length < 2)
        {
            return;
        }

        // Generate two partition arrays
        int[] leftArray = new int[array.Length / 2];
        int[] rightArray = new int[array.Length - leftArray.Length];
        int rightArrayIndex = 0;

        for (int i = 0; i < leftArray.Length; i++)
        {
            leftArray[i] = array[i];
        }

        for (int i = leftArray.Length; i < array.Length; i++)
        {
            rightArray[rightArrayIndex] = array[i];
            rightArrayIndex++;
        }

        // Recursively merge-sorts the leftArray
        mergeSort(leftArray);
        // Recursively merge-sorts the rightArray
        mergeSort(rightArray);

        // Helper-array(the result from the merge of leftArray and rightArray)
        int[] helper = merge(leftArray, rightArray);
        // Overwrite the main array elements
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = helper[i];
        }
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

        mergeSort(array);

        // Print the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}