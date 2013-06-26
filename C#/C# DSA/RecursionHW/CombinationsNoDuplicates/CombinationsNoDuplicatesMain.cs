using System;

namespace CombinationsNoDuplicates
{
    public class CombinationsNoDuplicatesMain
    {
        public static void Main(string[] args)
        {
            Console.Write("N (the size of the set) = ");
            int n = int.Parse(Console.ReadLine()); // The length of the set
            int[] set = GenerateSet(n);

            Console.Write("K (the count of the elements in each combination) = ");
            int k = int.Parse(Console.ReadLine()); // The number of elements in each combination
            int[] arr = new int[k];

            GenerateCombinationsWithoutDuplicates(arr, set, 0, 0);
        }

        /// <summary>
        /// Generates all the combinations without duplicates of K elements from N - element set
        /// </summary>
        /// <param name="currentCombination">An array which holds a combination at a current state</param>
        /// <param name="set">The set of elements</param>
        /// <param name="combIndex">The index that walks through the currentCombination array</param>
        /// <param name="setIndex">The index that walks through the set</param>
        public static void GenerateCombinationsWithoutDuplicates(int[] currentCombination, int[] set, int combIndex, int setIndex)
        {
            if (combIndex == currentCombination.Length)
            {
                // A combination has been found
                PrintArray(currentCombination);
                return;
            }
            else
            {
                for (int i = setIndex; i < set.Length; i++)
                {
                    currentCombination[combIndex] = set[i];
                    GenerateCombinationsWithoutDuplicates(currentCombination, set, combIndex + 1, i + 1);
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
