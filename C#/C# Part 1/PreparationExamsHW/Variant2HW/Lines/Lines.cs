using System;

class Lines
{
    static double Pow(double x, double y)
    {
        double result = 1;
        for (int i = 0; i < y; i++)
        {
            result *= x;
        }
        return result;
    }

    static void Main()
    {
        int[] bytes = new int[8];
        int[] rowBytes = new int[8];
        int[] colBytes = new int[8];
        int[,] bitMap = new int[8, 8];
        int maxLen = 0;
        int maxLenCount = 0;

        // read the input and generating rowBytes
        for (int i = 0; i < 8; i++)
        {
            bytes[i] = byte.Parse(Console.ReadLine());
            rowBytes[i] = bytes[i];
        }

        // generating the matrix(the bitMap) with the exact bits possitions
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

        // generating the colBytes with the bitMap
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (bitMap[i, j] == 1)
                {
                    colBytes[j] += (int)Pow(2.0, i);
                }
            }
        }

        // calculating the maxLen
        for (int i = 0; i < 8; i++)
        {
            // checking the rows of the matrix
            int trailingOnes = 0;

            for (int j = 0; j < 8; j++)
            {
                if (((rowBytes[i] >> j) & 1) == 1)
                {
                    trailingOnes++;
                    if (trailingOnes > maxLen)
                    {
                        maxLen = trailingOnes;
                    }
                }
                else
                {
                    trailingOnes = 0;
                }
            }

            // checking the columns of the matrix
            trailingOnes = 0;

            for (int j = 0; j < 8; j++)
            {
                if (((colBytes[i] >> j) & 1) == 1)
                {
                    trailingOnes++;
                    if (trailingOnes > maxLen)
                    {
                        maxLen = trailingOnes;
                    }
                }
                else
                {
                    trailingOnes = 0;
                }
            }
        }

        // calculating the maxLenCount
        for (int i = 0; i < 8; i++)
        {
            // checking the rows of the matrix
            int trailingOnes = 0;

            for (int j = 0; j < 8; j++)
            {
                if (((rowBytes[i] >> j) & 1) == 1)
                {
                    trailingOnes++;
                    if (trailingOnes == maxLen)
                    {
                        maxLenCount++;
                    }
                }
                else
                {
                    trailingOnes = 0;
                }
            }

            // checking the columns of the matrix
            trailingOnes = 0;

            for (int j = 0; j < 8; j++)
            {
                if (((colBytes[i] >> j) & 1) == 1)
                {
                    trailingOnes++;
                    if (trailingOnes == maxLen)
                    {
                        maxLenCount++;
                    }
                }
                else
                {
                    trailingOnes = 0;
                }
            }
        }

        if (maxLen == 1)
        {
            maxLenCount = maxLenCount / 2;
        }

        // output the result
        Console.WriteLine(maxLen);
        Console.WriteLine(maxLenCount);
    }
}