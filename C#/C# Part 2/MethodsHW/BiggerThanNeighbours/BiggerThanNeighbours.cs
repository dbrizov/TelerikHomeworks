using System;

class BiggerThanNeighbours
{
    public static bool CheckNeighbours(int[] arr, int index)
    {
        if (index >= 1 && index < arr.Length - 1)
        {
            if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Console.WriteLine("Incorrect Index!");
            return false;
        }
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
        // Input array length
        Console.Write("Array Length = ");
        int arrayLength = int.Parse(Console.ReadLine());

        // Input array elements
        int[] array = new int[arrayLength];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        PrintArray(array);

        // Input index
        Console.Write("Index = ");
        int index = int.Parse(Console.ReadLine());

        Console.WriteLine(CheckNeighbours(array, index));
    }
}