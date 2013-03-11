using System;

class ThirdBitIsZeroOrOne
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int mask = 1 << 3;

        if ((number & mask) == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(1);
        }
    }
}