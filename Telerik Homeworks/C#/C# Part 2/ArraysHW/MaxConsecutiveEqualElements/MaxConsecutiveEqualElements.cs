using System;

class MaxConsecutiveEqualElements
{
    static void Main(string[] args)
    {
        int arrayLength; // The length of the array
        int[] array; // The array
        int maxCount = 1; // The count of the max equal consecutive elements
        int currentCount = 1; // The current count of the max equal consecutive elements
        int previousElement; // Helper for the for() loop
        int constructElement = 0; // The element the constructs the row of consecutive elements

        // Input the array length
        Console.Write("array length = ");
        arrayLength = int.Parse(Console.ReadLine());

        // Input the array elements
        array = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("number[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Find the maxCount and the constructElement
        previousElement = array[0];
        for (int i = 1; i < arrayLength; i++)
        {
            if (array[i] == previousElement)
            {
                currentCount++;
                if (maxCount < currentCount)
                {
                    maxCount = currentCount;
                    constructElement = array[i];
                }
            }
            else
            {
                currentCount = 1;
            }
            previousElement = array[i];
        }

        // Print the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0, -2}", array[i]);
        }
        Console.WriteLine();

        // Print the max equal consecutive elements
        if (maxCount > 1)
        {
            Console.Write("Max consecutive equal elements -> ");
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write("{0, -2}", constructElement);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No consecutive elements exist!");
        }
    }
}