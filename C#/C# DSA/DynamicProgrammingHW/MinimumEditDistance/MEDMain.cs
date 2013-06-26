using System;

namespace MinimumEditDistance
{
    public class MEDMain
    {
        public static decimal CostDelete = 0.9m;
        public static decimal CostInsert = 0.8m;
        public static decimal CostReplace(string str1, string str2, int index1, int index2)
        {
            if (str1[index1] == str2[index2])
            {
                return 0.0m;
            }

            return 1.0m;
        }

        public static decimal Min(decimal a, decimal b, decimal c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public static decimal GetMinEditDistance(string actual, string target)
        {
            // Initialization
            actual = "_" + actual;
            target = "_" + target;
            decimal[,] table = new decimal[actual.Length, target.Length];

            for (int i = 0; i < actual.Length; i++)
            {
                table[i, 0] = i * CostDelete;
            }

            for (int i = 0; i < target.Length; i++)
            {
                table[0, i] = i * CostInsert;
            }

            // Minimum edit distance calculation
            for (int i = 1; i < actual.Length; i++)
            {
                for (int j = 1; j < target.Length; j++)
                {
                    table[i, j] = Min(
                        table[i - 1, j - 1] + CostReplace(actual, target, i, j),
                        table[i, j - 1] + CostInsert,
                        table[i - i, j] + CostDelete);
                }
            }

            return table[actual.Length - 1, target.Length - 1];
        }

        public static void Main()
        {
            string actual = "developer";
            string target = "enveloped";

            decimal minimumEditDistance = GetMinEditDistance(actual, target);
            Console.WriteLine(minimumEditDistance);
        }
    }
}
