using System;

class GetIndex
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

    public static int Index(int[] arr)
    {
        int resultIndex = -1;

        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (CheckNeighbours(arr, i))
            {
                resultIndex = i;
                break;
            }
        }

        return resultIndex;
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

        Console.WriteLine(Index(array));
    }
}