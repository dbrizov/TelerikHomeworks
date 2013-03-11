using System;

class ArrayBinSearch
{
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
        // Input N and K
        Console.Write("N = ");
        int arrayLength = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        // Input the array
        int[] array = new int[arrayLength];
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write("array[{0}] = ", index);
            array[index] = int.Parse(Console.ReadLine());
        }

        // Makes a copyArray that is with 1 more element (the K element)
        int[] copyArray = new int[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            copyArray[i] = array[i];
        }

        copyArray[copyArray.Length - 1] = k;

        // Sort array
        Array.Sort(copyArray);

        // Print array
        PrintArray(copyArray);

        // Finds the index on which K is placed after the sort
        int kIndex = Array.BinarySearch(copyArray, k);

        // Finds it there are more element equal to K
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == k)
            {
                counter++;
                break;
            }
        }

        // if there are not equal element to K then return copyArray[kIndex - 1];
        if (counter == 0 && kIndex > 0)
        {
            Console.WriteLine("The larges element <= K is " + copyArray[kIndex - 1]);
        }
        // else return the K element
        else if (counter > 0)
        {
            Console.WriteLine("The largest element <= K is " + k);
        }
    }
}