using System;

class PrintIntegers
{
    static void Main()
    {
        Console.WriteLine("[1, n]");
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
