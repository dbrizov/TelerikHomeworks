using System;

class SequenceOfGivenSum
{
    static void Main(string[] args)
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8, 3, 5, 3, 8, 1, 2, 9, 1, -1 };
        int sum; // The result sum
        int currentSum; // The current sum
        int sequenceLength;

        // Print the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        // Input the sum
        Console.Write("Sum = ");
        sum = int.Parse(Console.ReadLine());

        // Find the sequence (sequences) of the given sum
        for (int i = 0; i < array.Length; i++)
        {
            currentSum = array[i];
            sequenceLength = 1;
            for (int j = i + 1; j < array.Length; j++)
            {
                currentSum += array[j];
                sequenceLength++;

                // Print the sequence
                if (currentSum == sum)
                {
                    for (int k = j - sequenceLength + 1; k <= j; k++)
                    {
                        Console.Write(array[k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}