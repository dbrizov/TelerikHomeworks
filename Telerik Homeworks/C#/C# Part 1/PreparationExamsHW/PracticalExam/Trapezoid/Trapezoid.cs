using System;
using System.Diagnostics;

class Trapezoid
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());

        // printing the top side
        for (int i = 0; i < 2 * N; i++)
        {
            if (i < N)
            {
                Console.Write('.');
            }
            else
            {
                Console.Write('*');
            }
        }
        Console.WriteLine();

        byte k = (byte)(N - 1);

        // printing the space between the top and the bottom sides
        for (int i = 0; i < N - 1; i++)
        {
            for (int j = 0; j < 2 * N; j++)
            {
                if (j == k || j == 2 * N - 1)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }

            k--;
            Console.WriteLine();
        }

        // printing the bottom side
        for (int i = 0; i < 2 * N; i++)
        {
            Console.Write('*');
        }
        Console.WriteLine();
    }
}