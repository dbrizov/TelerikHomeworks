using System;

namespace Permutations
{
    public class PermutationsMain
    {
        public static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            bool[] used = new bool[n];

            GeneratePermutations(arr, used, 0);
        }

        public static void GeneratePermutations(int[] currentPermutation, bool[] used, int index)
        {
            if (index == currentPermutation.Length)
            {
                PrintArray(currentPermutation);
                return;
            }
            else
            {
                for (int i = 0; i < currentPermutation.Length; i++)
                {
                    if (!(used[i]))
                    {
                        used[i] = true;
                        currentPermutation[index] = i + 1;
                        GeneratePermutations(currentPermutation, used, index + 1);
                        used[i] = false;
                    }
                }
            }
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
