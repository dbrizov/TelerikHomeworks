using System;
using System.Numerics;

class CalculateFactorial
{
    public static BigInteger Factorial(int n)
    {
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }

    static void Main(string[] args)
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(Factorial(i));
            Console.WriteLine(new string('-', 79));
        }
    }
}