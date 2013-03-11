using System;

class SortByStringLength
{
    public static void PrintArray(string[] arr)
    {
        Console.WriteLine();
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
        Console.WriteLine("---------------------------");
    }

    static void Main(string[] args)
    {
        // Input the length of the array
        Console.Write("Array Length = ");
        int arrayLength = int.Parse(Console.ReadLine());

        string[] array = new string[arrayLength];

        // Input the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = Console.ReadLine();
        }

        PrintArray(array);

        Array.Sort(array, (x, y) =>
            {
                if (x.Length < y.Length) return -1;
                else if (x.Length > y.Length) return 1;
                else return 0;
            });

        PrintArray(array);
    }
}