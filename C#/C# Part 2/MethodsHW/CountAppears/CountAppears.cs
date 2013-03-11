using System;

class CountAppears
{
    public static int GetCounts(int[] arr, int number)
    {
        int counter = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == number)
            {
                counter++;
            }
        }

        return counter;
    }

    public static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // User input
        Console.Write("Array Length = ");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.Write("Number = ");
        int number = int.Parse(Console.ReadLine());

        // Input the array
        int[] array = new int[arrayLength];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("arrau[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        PrintArray(array);

        Console.WriteLine("{0} appears {1} times in the array", number, GetCounts(array, number));
    }
}