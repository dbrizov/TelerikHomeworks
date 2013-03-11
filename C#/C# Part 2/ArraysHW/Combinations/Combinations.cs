using System;
using System.Collections.Generic;

class Combinations
{
    // It works very slow with very big values of "n"
    // With n > 30 there is a chance for overflow
    public static List<int> GenerateCombinations(int n, int k, int[] set)
    {
        // Generate all subsets (combinations) with length == k
        List<int> subsets = new List<int>();
        int subsetsMaxCount = (int)Math.Pow(2, n);

        for (int subset = 0; subset < subsetsMaxCount; subset++)
        {
            int counter = 0;

            for (int mainSetIndex = 0; mainSetIndex < set.Length; mainSetIndex++)
            {
                if (((subset >> mainSetIndex) & 1) == 1)
                {
                    counter++;
                }
            }

            if (counter == k)
            {
                subsets.Add(subset);
            }
        }

        return subsets;
    }

    static void Main(string[] args)
    {
        // User input
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("k= ");
        int k = int.Parse(Console.ReadLine());

        // Generate main set
        int[] mainSet = new int[n];
        for (int i = 0; i < n; i++)
        {
            mainSet[i] = i + 1;
        }

        // Generate combinations (subsets)
        List<int> combibations = GenerateCombinations(n, k, mainSet);

        // Print the combinations (subsets)
        for (int combIndex = 0; combIndex < combibations.Count; combIndex++)
        {
            Console.Write("{ ");
            for (int mainSetIndex = 0; mainSetIndex < n; mainSetIndex++)
            {
                if (((combibations[combIndex] >> mainSetIndex) & 1) == 1)
                {
                    Console.Write("{0} ", mainSet[mainSetIndex]);
                }
            }
            Console.WriteLine("}");
        }
    }
}