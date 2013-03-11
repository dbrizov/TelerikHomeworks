using System;

class SelectionSort
{
    // Selection Sort algorithm
    private static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            // Swap array[i] with array[minIndex];
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }

    static void Main(string[] args)
    {
        int arrayLength; // The array length
        int[] array; // The array

        // Input the array length
        Console.Write("Array length = ");
        arrayLength = int.Parse(Console.ReadLine());

        // Input the array elements
        array = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Print the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("-> array");

        // Sort the array
        Sort(array);

        // Print the sorted array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("-> sorted array");
    }
}