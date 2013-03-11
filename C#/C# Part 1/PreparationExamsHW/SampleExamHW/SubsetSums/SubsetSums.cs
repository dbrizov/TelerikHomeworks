using System;

class SubsetSums
{
    static void Main()
    {
        // input the sum
        long sum = long.Parse(Console.ReadLine());

        // input the mainSetSize
        byte mainSetSize = byte.Parse(Console.ReadLine());

        long[] mainSet = new long[mainSetSize];

        // The input of the main sets
        for (int i = 0; i < mainSetSize; i++)
        {
            mainSet[i] = long.Parse(Console.ReadLine());
        }

        int numberOfSubsets = (int)Math.Pow(2.0, (double)mainSetSize);
        int[] subsets = new int[numberOfSubsets];

        // Generating all subsets
        for (int i = 0; i < numberOfSubsets; i++)
        {
            subsets[i] = i;
        }

        int counter = 0;

        // counting the subsets with the proper sum
        for (int i = 0; i < numberOfSubsets; i++)
        {
            long currentSum = 0;
            string subsetString = Convert.ToString(subsets[i], 2).PadLeft(mainSetSize, '0');

            for (int j = 0; j < mainSetSize; j++)
            {
                if (subsetString[j] == '1')
                {
                    currentSum += mainSet[j];
                }
            }

            if (currentSum == sum)
            {
                counter++;
            }
        }

        // I do this because the empty subsets has a default sum == 0
        if (sum == 0)
        {
            counter--;
        }

        Console.WriteLine(counter);
    }
}