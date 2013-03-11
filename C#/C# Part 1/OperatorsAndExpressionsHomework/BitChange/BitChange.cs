using System;

class BitChange
{
    static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine()); // integer number
        Console.Write("v=");
        int v = int.Parse(Console.ReadLine()); // bit value (0 or 1)
        Console.Write("p=");
        int p = int.Parse(Console.ReadLine()); // position

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0') + " -> " + n);

        int mask = 1 << p;

        if ((n & mask) == 0 && v == 1)
        {
            n = (n | mask);
        }
        else if ((n & mask) != 0 && v == 0)
        {
            n = (n & ~(mask));
        }
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0') + " -> " + n);
    }
}
