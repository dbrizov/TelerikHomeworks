using System;

namespace RefactoredArrayStatistics
{
    public static class DoubleArrayStatistics
    {
        public static void PrintMaxElement(double[] arr)
        {
            Console.WriteLine(GetMaxElement(arr));
        }

        public static void PrintMinElement(double[] arr)
        {
            Console.WriteLine(GetMinElement(arr));
        }

        public static void PrintAverage(double[] arr)
        {
            Console.WriteLine(GetAvetage(arr));
        }

        public static void PrintAllStatistics(double[] arr)
        {
            PrintMaxElement(arr);
            PrintMinElement(arr);
            PrintAverage(arr);
        }

        private static double GetMaxElement(double[] arr)
        {
            double max = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }

            return max;
        }

        private static double GetMinElement(double[] arr)
        {
            double min = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min < arr[i])
                {
                    min = arr[i];
                }
            }

            return min;
        }

        private static double GetAvetage(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            double average = sum / arr.Length;

            return average;
        }
    }
}
