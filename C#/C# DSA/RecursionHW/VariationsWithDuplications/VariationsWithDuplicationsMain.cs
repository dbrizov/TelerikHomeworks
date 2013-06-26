using System;

namespace VariationsWithDuplications
{
    public class VariationsWithDuplicationsMain
    {
        public static void Main(string[] args)
        {
            Console.Write("N (the size of the set) = ");
            int n = int.Parse(Console.ReadLine());
            int[] set = GenerateSet(n);

            Console.Write("K (the count of the elements in each variation) = ");
            int k = int.Parse(Console.ReadLine()); // The number of elements in each variation
            int[] arr = new int[k];

            GenerateVariationsWithDuplications(arr, set, 0);
        }

        public static void GenerateVariationsWithDuplications(int[] currentVariation, int[] set, int index)
        {
            if (index == currentVariation.Length)
            {
                // A variation has been found
                PrintArray(currentVariation);
                return;
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    currentVariation[index] = set[i];
                    GenerateVariationsWithDuplications(currentVariation, set, index + 1);
                }
            }
        }

        public static int[] GenerateSet(int setLength)
        {
            int[] set = new int[setLength];
            for (int i = 0; i < setLength; i++)
            {
                set[i] = i + 1;
            }

            return set;
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
