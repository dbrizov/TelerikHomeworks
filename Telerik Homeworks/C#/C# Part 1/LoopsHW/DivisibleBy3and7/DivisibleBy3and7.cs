using System;

class DivisibleBy3and7
{
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            if (i % 21 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
