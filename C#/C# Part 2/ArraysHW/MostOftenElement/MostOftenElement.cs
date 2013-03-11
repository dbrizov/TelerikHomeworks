using System;

class MostOftenElement
{
    // Selection Sort
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
        int arrayLength; // The array length
        int oftenCounter = 1; // counter for the most often element
        int maxOftenCounter = 1; // this will be the result (the max counter for the most often element)
        int previousElement; // Helper for the for() loop
        int maxOftenElementValue = 0; // the value of the max often element

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
        Console.WriteLine();

        // Sort the array
        sort(array);

        // Find the max often element
        previousElement = array[0];
        for (int i = 1; i < arrayLength; i++)
        {
            if (previousElement == array[i])
            {
                oftenCounter++;
                if (maxOftenCounter < oftenCounter)
                {
                    maxOftenCounter = oftenCounter;
                    maxOftenElementValue = array[i];
                }
            }
            else
            {
                oftenCounter = 1;
            }
            previousElement = array[i];
        }

        if (maxOftenCounter > 1)
        {
            Console.WriteLine("{0} -> ({1} times)", maxOftenElementValue, maxOftenCounter);
        }
        else
        {
            Console.WriteLine("No Such element exists!");
        }
    }
}