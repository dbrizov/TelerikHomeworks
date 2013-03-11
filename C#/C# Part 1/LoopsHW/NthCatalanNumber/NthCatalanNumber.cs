using System;
using System.Numerics;

class NthCatalanNumber
{
    static BigInteger Factorial(int number)
    {
        BigInteger fact = 1;

        if (number == 0)
        {
            return 1;
        }
        else
        {
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
            return fact;
        }
    }

    static BigInteger Catalan(int n)
    {
        return Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
    }

    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(Catalan(n));
    }
}