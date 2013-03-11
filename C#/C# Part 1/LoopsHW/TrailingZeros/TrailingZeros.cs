using System;

class TrailingZeros
{
    static void Main()
    {
        Console.Write("n= ");
        long n = long.Parse(Console.ReadLine());

        long trailingZeros = 0;
        while (n != 0)
        {
            n = n / 5;
            trailingZeros += n;
        }

        Console.WriteLine(trailingZeros);
    }
}