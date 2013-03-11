using System;

class Pillars
{
    static void Main()
    {
        // reading the input
        int[] bytes = new int[8];
        for (int i = 0; i < 8; i++)
        {
            bytes[i] = byte.Parse(Console.ReadLine());
        }

        // generating a matrix(bitMap) and counting the full cells
        int[,] bitMap = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int j = 7;
            while (bytes[i] != 0)
            {
                bitMap[i, j] = bytes[i] % 2;
                bytes[i] /= 2;
                j--;
            }
        }

        // generating an array with the number of full cells in each column
        int[] columnFullCells = new int[8];
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (bitMap[i, j] == 1)
                {
                    columnFullCells[j]++;
                }
            }
        }

        // searching for the right index
        for (int i = 0; i < 8; i++)
        {
            int k = i;
            int leftCounter = 0;
            int rightCounter = 0;

            for (int j = 0; j < k; j++)
            {
                leftCounter += columnFullCells[j];
            }
            for (int j = k + 1; j < 8; j++)
            {
                 rightCounter += columnFullCells[j];
            }

            if (leftCounter == rightCounter)
            {
                Console.WriteLine(7 - k);
                Console.WriteLine(leftCounter);
                break;
            }

            if (k == 7)
            {
                Console.WriteLine("No");
            }
        }
    }
}