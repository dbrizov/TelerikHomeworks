using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicFunctionsPerformance
{
    public class MathematicFunctionsPerformance
    {
        public delegate double MathFunction(double num);

        public static void DisplayMathFunctionPerformance(MathFunction func, int iterationsCount)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double num = 1.0;
            for (int i = 0; i < iterationsCount; i++)
            {
                num = func(num);
            }

            sw.Stop();

            Console.WriteLine("{0}: {1}", func.Method, sw.Elapsed);
        }

        public static void Main(string[] args)
        {
            const int IterationsCount = 10000000;

            /* 
             * The Math.Sin, Math.Sqrt, Math.Log take only double arguments and return only double
             * arguents. That means if I give it a float or a decimal value, this value will
             * be converted to double. That means I just have to compare the speed of the 3 methods
             */

            Console.WriteLine("Performance:");
            DisplayMathFunctionPerformance(Math.Sqrt, IterationsCount);
            DisplayMathFunctionPerformance(Math.Log, IterationsCount);
            DisplayMathFunctionPerformance(Math.Sin, IterationsCount);
        }
    }
}
