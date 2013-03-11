using System;

class FirTree
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int width = 2 * height - 3;

        int leftIndex = width - width / 2 - 1;
        int rightIndex = leftIndex;

        // printing the top and the body of the tree
        for (int i = 0; i < height - 1; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j < leftIndex || j > rightIndex)
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write('*');
                }
            }

            leftIndex--;
            rightIndex++;
            Console.WriteLine();
        }

        // printing the stem of the tree
        for (int i = 0; i < width; i++)
        {
            if (i == width - width / 2 - 1)
            {
                Console.Write('*');
            }
            else
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
    }
}