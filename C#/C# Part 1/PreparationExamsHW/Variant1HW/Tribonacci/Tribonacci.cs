using System;
using System.Numerics;

class Tribonacci
{

    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        BigInteger tn = 0;
        for (int i = 0; i < n; i++)
        {
            tn = t1;
            t1 = t2;
            t2 = t3;
            t3 = tn + t1 + t2;
        }

        Console.WriteLine(tn);
    }
}