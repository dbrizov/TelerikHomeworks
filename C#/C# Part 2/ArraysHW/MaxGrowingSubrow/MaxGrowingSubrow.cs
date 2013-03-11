using System;

class MaxGrowingSubrow
{
    static void Main(string[] args)
    {
        int arrayLength; // The array length
		int[] array; // The array
		int previousElement; // Helper for the for() loop
		int currentGrowingSubrowLength = 1; // The current length of the subrow
		int maxGrowingSubrowLength = 1; // The max length of the subrow
		
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
            Console.Write("{0, -2}", array[i]);
        }
        Console.WriteLine();
		
		// Find length of the max growing subrow and the index of the last element in the subrow
		previousElement = array[0];
        int index = 0; // The index of the last element of the growing subrow
		for (int i = 1; i < arrayLength; i++)
		{
			if (previousElement < array[i])
			{
				currentGrowingSubrowLength++;
				if (maxGrowingSubrowLength < currentGrowingSubrowLength)
				{
					maxGrowingSubrowLength = currentGrowingSubrowLength;
                    index = i;
				}
			}
			else
			{
				currentGrowingSubrowLength = 1;
			}
			previousElement = array[i];
		}

        // Print the max growing subrow
        if (maxGrowingSubrowLength > 1)
        {
            Console.Write("Max growing subrow -> ");
            for (int i = index - maxGrowingSubrowLength + 1; i <= index; i++)
            {
                Console.Write("{0, -2}", array[i]);
            }
            Console.WriteLine();
        }
    }
}