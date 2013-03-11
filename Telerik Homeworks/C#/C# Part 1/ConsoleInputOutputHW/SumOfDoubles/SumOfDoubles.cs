using System;

class SumOfDoubles
{
    static void Main()
    {
        Console.Write("#numbers: ");
        int n = int.Parse(Console.ReadLine()); // #numbers

        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write("number" + (i + 1) + " = ");
            sum = sum + double.Parse(Console.ReadLine());
        }

        Console.WriteLine("sum = " + sum);
    }
}
