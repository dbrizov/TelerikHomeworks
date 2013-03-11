using System;

class SubrowWithMaxSum
{
    static void Main(string[] args)
    {
        int arrayLength; // The length of the array
        int[] array; // The array { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int currentSum = 0; // The current sum
        int maxSum = 0; // The max sum
        int subrowLength = 0; // The length of the subrow with max sum
        int subrowStartIndex = 0; // The index of the first elements of the subrow with max sum
        int currentSubrowLength; // The length of the current checked subrow

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

        // Find the subrow with max sum and the starting index of that subrow
        // First checks all subrows with length == 2, length == 3, ... last with length == array.Length
        for (currentSubrowLength = 2; currentSubrowLength <= array.Length; currentSubrowLength++)
        {
            for (int i = 0; i <= array.Length - currentSubrowLength; i++)
            {
                currentSum = 0;
                for (int j = i; j < i + currentSubrowLength; j++)
                {
                    currentSum += array[j];
                }

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                    subrowStartIndex = i;
                    subrowLength = currentSubrowLength;
                }
            }
        }

        // Print the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        // Print the maxSubrow
        for (int i = subrowStartIndex; i < subrowStartIndex + subrowLength; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("-> (sum = {0})", maxSum);
    }
}