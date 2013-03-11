using System;

class ForestRoad
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int copyOfWidth = width;

        for (int i = 0; i < 2 * width - 1; i++)
        {
            if (i < width)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == j)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
            }
            else
            {
                for (int j = 0; j < width; j++)
                {
                    if (copyOfWidth - 2 == j)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                copyOfWidth--;
            }
            Console.WriteLine();
        }
    }
}