using System;

class DifferentMatrixes
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, 3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Input
        Console.Write("Rows = Cols = ");
        int size = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];

        // a)
        int number = 1;
        for (int col = 0; col < size; col++)
        {
            for (int row = 0; row < size; row++)
            {
                matrix[row, col] = number;
                number++;
            }
        }

        PrintMatrix(matrix);

        // b)
        number = 1;
        for (int col = 0; col < size; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < size; row++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }
            else
            {
                for (int row = size - 1; row >= 0; row--)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }
        }

        PrintMatrix(matrix);

        // c)
        // Generates all under the main diagonal + the main diagonal
        number = 1;
        for (int i = 0; i < size; i++)
        {
            int row = size - i - 1;
            int col = 0;

            while (row <= size - 1)
            {
                matrix[row, col] = number;
                number++;
                row++;
                col++;
            }
        }

        // Generates all above the main diagonal - the main diagonal
        for (int i = 0; i < size - 1; i++)
        {
            int row = 0;
            int col = i + 1;

            while (col <= size - 1)
            {
                matrix[row, col] = number;
                number++;
                row++;
                col++;
            }
        }

        PrintMatrix(matrix);

        // d)
        number = 1;
        int minRow = 0;
        int maxRow = size - 1;
        int minCol = 0;
        int maxCol = size - 1;

        while (number <= size * size)
        {
            for (int row = minRow; row <= maxRow; row++) // down
            {
                matrix[row, minCol] = number;
                number++;
            }

            minCol++;

            for (int col = minCol; col <= maxCol; col++) // right
            {
                matrix[maxRow, col] = number;
                number++;
            }

            maxRow--;

            for (int row = maxRow; row >= minRow; row--) // up
            {
                matrix[row, maxCol] = number;
                number++;
            }

            maxCol--;

            for (int col = maxCol; col >= minCol; col--) // left
            {
                matrix[minRow, col] = number;
                number++;
            }

            minRow++;
        }

        PrintMatrix(matrix);
    }
}