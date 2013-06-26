using System;

namespace PermutationsWithRepetitions
{
    public class PermutationsMain
    {
        public static void Main(string[] args)
        {
            // The set must be sorted for the algorithm to work
            int[] set = new int[] { 1, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Permute(set, 0);
        }

        public static void Permute(int[] set, int start)
        {
            PrintPermutation(set);
            int tmp = 0;

            if (start < set.Length)
            {
                for (int i = set.Length - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < set.Length; j++)
                    {
                        if (set[i] != set[j])
                        {
                            // Swap set[i] <--> set[j]
                            tmp = set[i];
                            set[i] = set[j];
                            set[j] = tmp;

                            Permute(set, i + 1);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping
                    tmp = set[i];
                    for (int k = i; k < set.Length - 1; )
                    {
                        set[k] = set[++k];
                    }

                    set[set.Length - 1] = tmp;
                }
            }
        }

        public static void PrintPermutation(int[] permutation)
        {
            for (int i = 0; i < permutation.Length; i++)
            {
                Console.Write(permutation[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
