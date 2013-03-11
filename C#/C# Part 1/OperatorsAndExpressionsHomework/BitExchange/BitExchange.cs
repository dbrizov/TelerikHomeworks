using System;

class BitExchange
{
    static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine()); // integer number

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0') + " -> " + n);

        int counter = 24;

        for (int i = 3; i <= 5; i++)
        {
            if (((1 << i) & n) != 0 && ((1 << (counter)) & n) == 0)
            {
                n = n & ~(1 << i);
                n = n | (1 << (counter));
            }
            else if (((1 << i) & n) == 0 && ((1 << (counter)) & n) != 0)
            {
                n = n | (1 << i);
                n = n & ~(1 << (counter));
            }
            counter++;
        }

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0') + " -> " + n);
    }
}
