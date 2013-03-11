using System;

class DevisionByFive
{
    static void Main()
    {
        Console.WriteLine("[a, b]");
        Console.Write("a = ");
        uint a = uint.Parse(Console.ReadLine());
        Console.Write("b = ");
        uint b = uint.Parse(Console.ReadLine());

        uint counter = 0;

        for (uint i = a; i <= b; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }

        Console.WriteLine("counter = " + counter);
    }
}
