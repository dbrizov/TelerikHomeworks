using System;

namespace RefactoredArrayStatistics
{
    public class MainMethod
    {
        public static void Main(string[] args)
        {
            double[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            DoubleArrayStatistics.PrintMaxElement(arr);
            DoubleArrayStatistics.PrintMinElement(arr);
            DoubleArrayStatistics.PrintAverage(arr);
            DoubleArrayStatistics.PrintAllStatistics(arr);
        }
    }
}
