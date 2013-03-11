using System;

class SequenceInMatrix
{
    static void Main(string[] args)
    {
        // User input
        Console.Write("rows = ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("cols = ");
        int cols = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rows, cols];

        // Input the matrix
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }

        // Print the matrix
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0, -5} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        int maxCount = 1;
        string sequenceElement = string.Empty;

        // Check rows
        for (int row = 0; row < rows; row++)
        {
            int count = 1;
            string previousString = matrix[row, 0];
            for (int col = 1; col < cols; col++)
            {
                if (previousString == matrix[row, col])
                {
                    count++;
                    if (maxCount < count)
                    {
                        maxCount = count;
                        sequenceElement = matrix[row, col];
                    }
                }
                else
                {
                    count = 1;
                }

                previousString = matrix[row, col];
            }
        }

        // Check cols
        for (int col = 0; col < cols; col++)
        {
            int count = 1;
            string previousString = matrix[0, col];
            for (int row = 1; row < rows; row++)
            {
                if (previousString == matrix[row, col])
                {
                    count++;
                    if (maxCount < count)
                    {
                        maxCount = count;
                        sequenceElement = matrix[row, col];
                    }
                }
                else
                {
                    count = 1;
                }

                previousString = matrix[row, col];
            }
        }

        // Check the diagonals
        // Check under main diagonal + main diagonal
        for (int i = 0; i < rows; i++)
        {
            int row = rows - i - 1;
            int col = 0;

            int count = 1;
            string previousString = matrix[row, col];
            row++;
            col++;

            while (row <= rows - 1)
            {
                if (previousString == matrix[row, col])
                {
                    count++;
                    if (maxCount < count)
                    {
                        maxCount = count;
                        sequenceElement = matrix[row, col];
                    }
                }
                else
                {
                    count = 1;
                }

                previousString = matrix[row, col];
                row++;
                col++;
            }
        }

        // Check above main diagonal
        for (int i = 0; i < cols - 1; i++)
        {
            int row = 0;
            int col = i + 1;

            int count = 1;
            string previousString = matrix[row, col];
            row++;
            col++;

            while (col <= cols - 1)
            {
                if (previousString == matrix[row, col])
                {
                    count++;
                    if (maxCount < count)
                    {
                        maxCount = count;
                        sequenceElement = matrix[row, col];
                    }
                }
                else
                {
                    count = 1;
                }

                previousString = matrix[row, col];
                row++;
                col++;
            }
        }

        // Print max sequence
        for (int i = 0; i < maxCount; i++)
        {
            Console.Write("{0} ", sequenceElement);
        }
        Console.WriteLine(" -> " + maxCount);
    }
}