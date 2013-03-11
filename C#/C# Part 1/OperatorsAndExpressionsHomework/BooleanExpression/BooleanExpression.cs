using System;

class BooleanExpression
{
    static void Main()
    {
        // the p-th bit is 1?
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine()); // number
        Console.Write("p= ");
        int p = int.Parse(Console.ReadLine()); // position

        int mask = 1 << p;

        if ((n & mask) == 0)
        {
            Console.WriteLine(false);
        }
        else
        {
            Console.WriteLine(true);
        }
    }
}