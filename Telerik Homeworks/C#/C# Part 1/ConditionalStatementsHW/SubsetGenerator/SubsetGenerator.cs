using System;

class SubsetGenerator
{
    static void Main()
    {
        Console.Write("Main set size= ");
        int mainSetSize = int.Parse(Console.ReadLine());

        Console.WriteLine("Input the main set:");
        int[] mainSet = new int[mainSetSize];
        // The input of the main sets
        for (int i = 0; i < mainSetSize; i++)
        {
            Console.Write("Number-{0}= ", i + 1);
            mainSet[i] = int.Parse(Console.ReadLine());
        }

        int numberOfSubsets = (int)Math.Pow(2.0, (double)mainSetSize);
        int[] subsets = new int[numberOfSubsets];
        // Generating all subsets
        for (int i = 0; i < numberOfSubsets; i++)
        {
            subsets[i] = i;
        }

        //// Printing all subsets
        //for (int i = 0; i < numberOfSubsets; i++)
        //{
        //    string subsetString = Convert.ToString(subsets[i], 2).PadLeft(mainSetSize, '0');
        //    Console.Write("{ ");
        //    for (int j = 0; j < mainSetSize; j++)
        //    {
        //        if (subsetString[mainSetSize - 1 - j] == '1')
        //        {
        //            Console.Write(mainSet[j] + " ");
        //        }
        //    }
        //    Console.WriteLine("}");
        //}

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Subsets with sum == 0:");

        // Printing all subsets with sum == 0
        for (int i = 0; i < numberOfSubsets; i++)
        {
            int sum = 0;
            string subsetString = Convert.ToString(subsets[i], 2).PadLeft(mainSetSize, '0');

            for (int j = 0; j < mainSetSize; j++)
            {
                if (subsetString[mainSetSize - 1 - j] == '1')
                {
                    sum += mainSet[j];
                }
            }

            if (sum == 0)
            {
                Console.Write("{ ");
                for (int j = 0; j < mainSetSize; j++)
                {
                    if (subsetString[mainSetSize - 1 - j] == '1')
                    {
                        Console.Write(mainSet[j] + " ");
                    }
                }
                Console.WriteLine("}");
            }
        }
    }
}
