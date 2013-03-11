using System;

class GreaterNumber
{
    static void Main()
    {
        double n1 = double.Parse(Console.ReadLine());
        double n2 = double.Parse(Console.ReadLine());

        Console.WriteLine(Math.Max(n1, n2));
    }
}
