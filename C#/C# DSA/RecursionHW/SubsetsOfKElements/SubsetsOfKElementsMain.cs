using System;

namespace SubsetsOfKElements
{
    public class SubsetsOfKElementsMain
    {
        public static void Main(string[] args)
        {
            string[] set = { "test", "rock", "fun" , "sleep"};

            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            string[] arr = new string[k];

            GenerateSubsets(arr, set, 0, 0);
        }

        public static void GenerateSubsets<T>(T[] subset, T[] set, int subsetIndex, int setIndex)
        {
            if (subsetIndex == subset.Length)
            {
                PrintArray(subset);
                return;
            }
            else
            {
                for (int i = setIndex; i < set.Length; i++)
                {
                    subset[subsetIndex] = set[i];
                    GenerateSubsets(subset, set, subsetIndex + 1, i + 1);
                }
            }
        }

        public static void PrintArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
