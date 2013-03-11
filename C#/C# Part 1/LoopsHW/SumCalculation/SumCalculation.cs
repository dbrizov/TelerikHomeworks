using System;

class SumCalculation
{
    static long Factorial(int number)
    {
        long fact = 1;

        checked
        {
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
        }

        return fact;
    }

    static void Main()
    {
        Console.Write("x= ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());

        double sum = 1;

        for (int i = 1; i <= n; i++)
        {
            sum += Factorial(i) / Math.Pow((double)x, (double)i);
        }

        Console.WriteLine("Sum= " + sum);
    }
}