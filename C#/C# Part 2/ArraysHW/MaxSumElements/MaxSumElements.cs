using System;

class MaxSumElements
{
    // Selection sort algorithm
    private static void sort(int[] array)
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
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }

    static void Main(string[] args)
    {
        int[] array; // The array
        int arrayLength; // N -> array length
        int[] elements; // The array in which I will put the K elements with max sum
        int elementsCount; // K -> the K searched elements
        int elementsIndex = 0; // Helper index for generation of the array of elements

        // Input the array length -> N
        Console.Write("Array length = ");
        arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength];

        // Input the number of elements with biggest sum -> K
        Console.Write("Number of elements with biggest sum = ");
        elementsCount = int.Parse(Console.ReadLine());
        elements = new int[elementsCount];

        // Input the array
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Print tha array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        // Sort the array
        sort(array);

        // Generate the array of elements (elements[])
        for (int i = arrayLength - 1; i >= arrayLength - elementsCount; i--)
        {
            elements[elementsIndex] = array[i];
            elementsIndex++;
        }

        // Print elements array
        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write(elements[i] + " ");
        }
        Console.WriteLine();
    }
}