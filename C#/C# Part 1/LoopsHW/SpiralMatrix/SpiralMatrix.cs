using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int elem = 1;
        int counter = 0;
        int row = 0;
        int col = 0;
        int maxRow = n - 1;
        int maxCol = n - 1;

        do
        {
            for (int i = col; i <= maxCol; i++) // right
            {
                matrix[row, i] = elem;
                elem++;
                counter++;
            }

            row++;

            for (int i = row; i <= maxRow; i++) // down
            {
                matrix[i, maxCol] = elem;
                elem++;
                counter++;
            }

            maxCol--;

            for (int i = maxCol; i >= col; i--) // left
            {
                matrix[maxRow, i] = elem;
                elem++;
                counter++;
            }

            maxRow--;

            for (int i = maxRow; i >= row; i--) // up
            {
                matrix[i, col] = elem;
                elem++;
                counter++;
            }

            col++;
        }
        while (counter < n * n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}