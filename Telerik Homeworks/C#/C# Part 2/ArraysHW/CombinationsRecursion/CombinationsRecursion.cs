using System;

class CombinationsRecursion
{
    static void PrintCombinations(int[] array, int n, int index, int currentNumber)
    {
        if (index == array.Length)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine("}");
        }
        else
        {
            for (int i = currentNumber; i <= n; i++)
            {
                array[index] = i;
                PrintCombinations(array, n, index + 1, i + 1);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("n = ");
        int setSize = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        int combinationsLength = int.Parse(Console.ReadLine());

        int[] combinations = new int[combinationsLength];
        PrintCombinations(combinations, setSize, 0, 1);
    }
}