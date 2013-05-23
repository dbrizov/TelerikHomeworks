using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsPerformance
{
    public class MainMethod
    {
        public static void DisplayPerformance<T>(T[] smallArr, T[] mediumArr, T[] bigArr)
            where T : IComparable
        {
            Stopwatch sw = new Stopwatch();

            // Small arrays performance test
            T[] smallArrClone1 = (T[])smallArr.Clone();
            T[] smallArrClone2 = (T[])smallArr.Clone();
            T[] smallArrClone3 = (T[])smallArr.Clone();

            sw.Start();
            SelectionSort.Sort(smallArrClone1);
            sw.Stop();
            Console.WriteLine("SelectionSort - arr.Length = 50: {0}", sw.Elapsed);

            sw.Reset();
            sw.Start();
            InsertionSort.Sort(smallArrClone2);
            sw.Stop();
            Console.WriteLine("InsertionSort - arr.Length = 50: {0}", sw.Elapsed);

            sw.Reset();
            sw.Start();
            QuickSort.Sort(smallArrClone3);
            sw.Stop();
            Console.WriteLine("QuickSort     - arr.Length = 50: {0}\n", sw.Elapsed);

            // Medium arrays performance test
            T[] mediumArrClone1 = (T[])mediumArr.Clone();
            T[] mediumArrClone2 = (T[])mediumArr.Clone();
            T[] mediumArrClone3 = (T[])mediumArr.Clone();

            sw.Reset();
            sw.Start();
            SelectionSort.Sort(mediumArrClone1);
            sw.Stop();
            Console.WriteLine("SelectionSort - arr.Length = 5000: {0}", sw.Elapsed);

            sw.Reset();
            sw.Start();
            InsertionSort.Sort(mediumArrClone2);
            sw.Stop();
            Console.WriteLine("InsertionSort - arr.Length = 5000: {0}", sw.Elapsed);

            sw.Reset();
            sw.Start();
            QuickSort.Sort(mediumArrClone3);
            sw.Stop();
            Console.WriteLine("QuickSort     - arr.Length = 5000: {0}\n", sw.Elapsed);

            // Big arrays performance test
            T[] bigArrClone1 = (T[])bigArr.Clone();
            T[] bigArrClone2 = (T[])bigArr.Clone();
            T[] bigArrClone3 = (T[])bigArr.Clone();

            sw.Reset();
            sw.Start();
            SelectionSort.Sort(bigArrClone1);
            sw.Stop();
            Console.WriteLine("SelectionSort - arr.Length = 15000: {0}", sw.Elapsed);

            sw.Reset();
            sw.Start();
            InsertionSort.Sort(bigArrClone2);
            sw.Stop();
            Console.WriteLine("InsertionSort - arr.Length = 15000: {0}", sw.Elapsed);

            sw.Reset();
            sw.Start();
            QuickSort.Sort(bigArrClone3);
            sw.Stop();
            Console.WriteLine("QuickSort     - arr.Length = 15000: {0}\n", sw.Elapsed);
        }

        public static void Main(string[] args)
        {
            const int SmallLength = 50;
            const int MediumLength = 5000;
            const int BigLength = 15000;

            Random randomNumber = new Random();

            // Initialize int arrays with small length
            int[] smallRandomIntArr = new int[SmallLength];
            for (int i = 0; i < smallRandomIntArr.Length; i++)
            {
                smallRandomIntArr[i] = randomNumber.Next(100);
            }

            int[] smallSortedIntArr = new int[SmallLength];
            for (int i = 0; i < smallSortedIntArr.Length; i++)
            {
                smallSortedIntArr[i] = i;
            }

            int[] smallReversedIntArr = new int[SmallLength];
            for (int i = 0; i < smallReversedIntArr.Length; i++)
            {
                smallReversedIntArr[i] = smallReversedIntArr.Length - i - 1;
            }

            // Initialize int arrays with medium length
            int[] mediumRandomIntArr = new int[MediumLength];
            for (int i = 0; i < mediumRandomIntArr.Length; i++)
            {
                mediumRandomIntArr[i] = randomNumber.Next(10000);
            }

            int[] mediumSortedIntArr = new int[MediumLength];
            for (int i = 0; i < mediumSortedIntArr.Length; i++)
            {
                mediumSortedIntArr[i] = i;
            }

            int[] mediumReversedIntArr = new int[MediumLength];
            for (int i = 0; i < mediumReversedIntArr.Length; i++)
            {
                mediumReversedIntArr[i] = mediumReversedIntArr.Length - i - 1;
            }

            // Intialize int arrays with big length
            int[] bigRandomIntArr = new int[BigLength];
            for (int i = 0; i < bigRandomIntArr.Length; i++)
            {
                bigRandomIntArr[i] = randomNumber.Next(30000);
            }

            int[] bigSortedIntArr = new int[BigLength];
            for (int i = 0; i < bigSortedIntArr.Length; i++)
            {
                bigSortedIntArr[i] = i;
            }

            int[] bigReversedIntArr = new int[BigLength];
            for (int i = 0; i < bigReversedIntArr.Length; i++)
            {
                bigReversedIntArr[i] = bigReversedIntArr.Length - i - 1;
            }

            Console.WriteLine("INT ARRAYS PERFORMANCE TEST:\n");
            Console.WriteLine("--RANDOM ARRAYS--");
            DisplayPerformance(smallRandomIntArr, mediumRandomIntArr, bigRandomIntArr);

            Console.WriteLine("--SORTED ARRAYS--");
            DisplayPerformance(smallSortedIntArr, mediumSortedIntArr, bigSortedIntArr);

            Console.WriteLine("--REVERSED ARRAYS--");
            DisplayPerformance(smallReversedIntArr, mediumReversedIntArr, bigReversedIntArr);

            // Initialize double arrays with small length
            double[] smallRandomDoubleArr = new double[SmallLength];
            for (int i = 0; i < smallRandomDoubleArr.Length; i++)
            {
                smallRandomDoubleArr[i] = randomNumber.NextDouble() * 100;
            }

            double[] smallSortedDoubleArr = new double[SmallLength];
            for (int i = 0; i < smallSortedDoubleArr.Length; i++)
            {
                smallSortedDoubleArr[i] = (double)i;
            }

            double[] smallReversedDoubleArr = new double[SmallLength];
            for (int i = 0; i < smallReversedDoubleArr.Length; i++)
            {
                smallReversedDoubleArr[i] = (double)(smallReversedDoubleArr.Length - i - 1);
            }

            // Initialize double arrays with medium length
            double[] mediumRandomDoubleArr = new double[MediumLength];
            for (int i = 0; i < mediumRandomDoubleArr.Length; i++)
            {
                mediumRandomDoubleArr[i] = randomNumber.NextDouble() * 10000;
            }

            double[] mediumSortedDoubleArr = new double[MediumLength];
            for (int i = 0; i < mediumSortedDoubleArr.Length; i++)
            {
                mediumSortedDoubleArr[i] = (double)i;
            }

            double[] mediumReversedDoubleArr = new double[MediumLength];
            for (int i = 0; i < mediumReversedDoubleArr.Length; i++)
            {
                mediumReversedDoubleArr[i] = (double)(mediumReversedDoubleArr.Length - i - 1);
            }

            // Intialize double arrays with big length
            double[] bigRandomDoubleArr = new double[BigLength];
            for (int i = 0; i < bigRandomDoubleArr.Length; i++)
            {
                bigRandomDoubleArr[i] = randomNumber.NextDouble() * 30000;
            }

            double[] bigSortedDoubleArr = new double[BigLength];
            for (int i = 0; i < bigSortedDoubleArr.Length; i++)
            {
                bigSortedDoubleArr[i] = (double)i;
            }

            double[] bigReversedDoubleArr = new double[BigLength];
            for (int i = 0; i < bigReversedDoubleArr.Length; i++)
            {
                bigReversedDoubleArr[i] = (double)(bigReversedDoubleArr.Length - i - 1);
            }

            Console.WriteLine(new string('-', 45));
            Console.WriteLine("DOUBLE ARRAYS PERFORMANCE TEST:\n");
            Console.WriteLine("--RANDOM ARRAYS--");
            DisplayPerformance(smallRandomDoubleArr, mediumRandomDoubleArr, bigRandomDoubleArr);

            Console.WriteLine("--SORTED ARRAYS--");
            DisplayPerformance(smallSortedDoubleArr, mediumSortedDoubleArr, bigSortedDoubleArr);

            Console.WriteLine("--REVERSED ARRAYS--");
            DisplayPerformance(smallReversedDoubleArr, mediumReversedDoubleArr, bigReversedDoubleArr);

            // Initialize decimal arrays with small length
            decimal[] smallRandomDedimalArr = new decimal[SmallLength];
            for (int i = 0; i < smallRandomDedimalArr.Length; i++)
            {
                smallRandomDedimalArr[i] = (decimal)(randomNumber.NextDouble() * 100);
            }

            decimal[] smallSortedDecimalArr = new decimal[SmallLength];
            for (int i = 0; i < smallSortedDecimalArr.Length; i++)
            {
                smallSortedDecimalArr[i] = (decimal)i;
            }

            decimal[] smallReversedDecimalArr = new decimal[SmallLength];
            for (int i = 0; i < smallReversedDecimalArr.Length; i++)
            {
                smallReversedDecimalArr[i] = (decimal)(smallReversedDecimalArr.Length - i - 1);
            }

            // Initialize decimal arrays with medium length
            decimal[] mediumRandomDecimalArr = new decimal[MediumLength];
            for (int i = 0; i < mediumRandomDecimalArr.Length; i++)
            {
                mediumRandomDecimalArr[i] = (decimal)(randomNumber.NextDouble() * 10000);
            }

            decimal[] mediumSortedDecimalArr = new decimal[MediumLength];
            for (int i = 0; i < mediumSortedDecimalArr.Length; i++)
            {
                mediumSortedDecimalArr[i] = (decimal)i;
            }

            decimal[] mediumReversedDecimalArr = new decimal[MediumLength];
            for (int i = 0; i < mediumReversedDecimalArr.Length; i++)
            {
                mediumReversedDecimalArr[i] = (decimal)(mediumReversedDecimalArr.Length - i - 1);
            }

            // Intialize decimal arrays with big length
            decimal[] bigRandomDecimalArr = new decimal[BigLength];
            for (int i = 0; i < bigRandomDecimalArr.Length; i++)
            {
                bigRandomDecimalArr[i] = (decimal)(randomNumber.NextDouble() * 30000);
            }

            decimal[] bigSortedDecimalArr = new decimal[BigLength];
            for (int i = 0; i < bigSortedDecimalArr.Length; i++)
            {
                bigSortedDecimalArr[i] = (decimal)i;
            }

            decimal[] bigReversedDecimalArr = new decimal[BigLength];
            for (int i = 0; i < bigReversedDecimalArr.Length; i++)
            {
                bigReversedDecimalArr[i] = (decimal)(bigReversedDecimalArr.Length - i - 1);
            }

            Console.WriteLine(new string('-', 45));
            Console.WriteLine("DECIMAL ARRAYS PERFORMANCE TEST:\n");
            Console.WriteLine("--RANDOM ARRAYS--");
            DisplayPerformance(smallRandomDedimalArr, mediumRandomDecimalArr, bigRandomDecimalArr);

            Console.WriteLine("--SORTED ARRAYS--");
            DisplayPerformance(smallSortedDecimalArr, mediumSortedDecimalArr, bigSortedDecimalArr);

            Console.WriteLine("--REVERSED ARRAYS--");
            DisplayPerformance(smallReversedDecimalArr, mediumReversedDecimalArr, bigReversedDecimalArr);
        }
    }
}
