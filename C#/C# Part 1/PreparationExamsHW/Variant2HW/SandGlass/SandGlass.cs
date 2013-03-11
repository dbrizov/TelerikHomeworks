using System;

class SandGlass
{
    static void Main()
    {
        // read the input
        int N = int.Parse(Console.ReadLine());

        int leftIndex = 0;
        int rightIndex = N - 1;

        // printing the upper part
        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j >= leftIndex && j <= rightIndex)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            leftIndex++;
            rightIndex--;
            Console.WriteLine();
        }
        leftIndex--;
        rightIndex++;

        // printing the middle part
        for (int i = 0; i < N; i++)
        {
            if (i == N / 2)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(".");
            }
        }
        Console.WriteLine();

        // printing the bottom part
        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j >= leftIndex && j <= rightIndex)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            leftIndex--;
            rightIndex++;
            Console.WriteLine();
        }
    }
}