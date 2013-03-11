using System;
using System.Numerics;

class FibonacciSum
{
    static BigInteger Fibonacci(int number)
    {
        BigInteger first = 0;
        BigInteger second = 1;

        if (number == 1)
        {
            return 0;
        }
        else if (number == 2)
        {
            return 1;
        }
        else
        {
            BigInteger result = 0;
            for (int i = 0; i < number; i++)
            {
                result = first;
                first = second;
                second = result + first;
            }
            return result;
        }
    }

    static void Main()
    {
        BigInteger sum = 0;

        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            sum += Fibonacci(i);
        }

        Console.WriteLine(sum);
    }
}
