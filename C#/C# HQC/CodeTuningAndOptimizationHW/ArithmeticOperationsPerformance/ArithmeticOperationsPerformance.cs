using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperationsPerformance
{
    public class ArithmeticOperationsPerformance
    {
        public static void DisplayAddPerformance<T>(int iterationsCount) where T : struct
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            T sum = (dynamic)1;
            for (int i = 0; i < iterationsCount; i++)
            {
                sum += (dynamic)i;
            }

            sw.Stop();

            Console.WriteLine("{0}: {1}", typeof(T), sw.Elapsed);
        }

        public static void DisplaySubtractPerformance<T>(int iterationsCount) where T : struct
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            T difference = (dynamic)iterationsCount;
            for (int i = 0; i < iterationsCount; i++)
            {
                difference -= (dynamic)i;
            }

            sw.Stop();

            Console.WriteLine("{0}: {1}", typeof(T), sw.Elapsed);
        }

        public static void DisplayIncrementPerformance<T>(int iterationsCount) where T : struct
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            T sum = (dynamic)1;
            for (int i = 0; i < iterationsCount; i++)
            {
                sum += (dynamic)1;
            }

            sw.Stop();

            Console.WriteLine("{0}: {1}", typeof(T), sw.Elapsed);
        }

        public static void DisplayMultiplyPerformance<T>(int iterationsCount) where T : struct
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            T product = (dynamic)1;
            for (int i = 0; i < iterationsCount; i++)
            {
                product *= (dynamic)product;
            }

            sw.Stop();

            Console.WriteLine("{0}: {1}", typeof(T), sw.Elapsed);
        }

        public static void DisplayDevidePerformance<T>(int iterationsCount) where T : struct
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            T number = (dynamic)1;
            for (int i = 0; i < iterationsCount; i++)
            {
                number /= (dynamic)number;
            }

            sw.Stop();

            Console.WriteLine("{0}: {1}", typeof(T), sw.Elapsed);
        }

        public static void Main(string[] args)
        {
            const int IterationsCount = 10000000;

            Console.WriteLine("Add performance:");
            DisplayAddPerformance<int>(IterationsCount);
            DisplayAddPerformance<long>(IterationsCount);
            DisplayAddPerformance<float>(IterationsCount);
            DisplayAddPerformance<double>(IterationsCount);
            DisplayAddPerformance<decimal>(IterationsCount);

            Console.WriteLine("\nSubtract performance:");
            DisplaySubtractPerformance<int>(IterationsCount);
            DisplaySubtractPerformance<long>(IterationsCount);
            DisplaySubtractPerformance<float>(IterationsCount);
            DisplaySubtractPerformance<double>(IterationsCount);
            DisplaySubtractPerformance<decimal>(IterationsCount);

            Console.WriteLine("\nIncrement performance:");
            DisplayIncrementPerformance<int>(IterationsCount);
            DisplayIncrementPerformance<long>(IterationsCount);
            DisplayIncrementPerformance<float>(IterationsCount);
            DisplayIncrementPerformance<double>(IterationsCount);
            DisplayIncrementPerformance<decimal>(IterationsCount);

            Console.WriteLine("\nMultiply performance:");
            DisplayMultiplyPerformance<int>(IterationsCount);
            DisplayMultiplyPerformance<long>(IterationsCount);
            DisplayMultiplyPerformance<float>(IterationsCount);
            DisplayMultiplyPerformance<double>(IterationsCount);
            DisplayMultiplyPerformance<decimal>(IterationsCount);

            Console.WriteLine("\nDevide performance:");
            DisplayDevidePerformance<int>(IterationsCount);
            DisplayDevidePerformance<long>(IterationsCount);
            DisplayDevidePerformance<float>(IterationsCount);
            DisplayDevidePerformance<double>(IterationsCount);
            DisplayDevidePerformance<decimal>(IterationsCount);
        }
    }
}
