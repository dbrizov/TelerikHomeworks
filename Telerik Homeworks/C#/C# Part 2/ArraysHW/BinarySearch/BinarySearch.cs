using System;

class BinarySearch
{
    private static int BinSearch(int[] arr, int elem, int leftIndex, int rightIndex)
    {
        int middleIndex;

        while (rightIndex >= leftIndex)
        {
            middleIndex = (rightIndex + leftIndex) / 2;

            if (arr[middleIndex] < elem)
            {
                leftIndex = middleIndex + 1;
            }
            else if (arr[middleIndex] > elem)
            {
                rightIndex = middleIndex - 1;
            }
            else
            {
                return middleIndex;
            }
        }

        return -1;
    }

    public static int BinSearch(int[] arr, int elem)
    {
        return BinSearch(arr, elem, 0, arr.Length - 1);
    }

    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine(BinSearch(array, 1));
        Console.WriteLine(BinSearch(array, 5));
        Console.WriteLine(BinSearch(array, 9));
        Console.WriteLine(BinSearch(array, 10));
        Console.WriteLine(BinSearch(array, 0));
        Console.WriteLine(BinSearch(array, 11));
    }
}