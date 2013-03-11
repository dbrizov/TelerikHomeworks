using System;

class BitValue
{
    static void Main()
    {
        Console.Write("i="); // integer
        int i = int.Parse(Console.ReadLine());
        Console.Write("b="); // #bit
        int b = int.Parse(Console.ReadLine());

        int mask = 1 << b;

        if ((i & mask) == 0)
        {
            Console.WriteLine("value=0");
        }
        else
        {
            Console.WriteLine("value=1");
        }
    }
}
