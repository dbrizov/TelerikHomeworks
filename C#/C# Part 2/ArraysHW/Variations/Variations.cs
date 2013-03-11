using System;

class Variations
{
    public static void printVariations(int[] arr, int index, int n)
    {
        if (index == arr.Length)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine("}");
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                printVariations(arr, index + 1, n);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        int[] variations = new int[k];

        printVariations(variations, 0, n);
    }
}