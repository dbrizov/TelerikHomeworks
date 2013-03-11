using System;
using System.Threading;
using System.Globalization;

class MathExpression
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());

        double numerator = N * N + (1 / (M * P)) + 1337;
        double denominator = N - (128.523123123 * P);
        double sin = Math.Sin((double)(int)(M % 180));

        Console.WriteLine("{0:F6}", (numerator / denominator) + sin);
    }
}