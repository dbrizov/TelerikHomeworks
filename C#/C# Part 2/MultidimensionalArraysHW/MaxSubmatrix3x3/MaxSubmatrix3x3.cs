using System;

class MaxSubmatrix3x3
{
    static void Main(string[] args)
    {
        int rows;
        int cols;
        int[,] matrix;
        int maxSum = 0;
        int currentSum = 0; // counter for currentSum
        int subRowIndex = 0; // the first row of the maxSubmatrix
        int subColIndex = 0; // the first column of the maxSubmatrix

        // User input
        Console.Write("Rows = ");
        rows = int.Parse(Console.ReadLine());

        Console.Write("Cols = ");
        cols = int.Parse(Console.ReadLine());

        matrix = new int[rows, cols];

        // Matrix input
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("matrix[{0}][{1}] = ", i, j);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Printing the matrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0, -4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Finding MaxSubmatrix
        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < cols - 2; j++)
            {
                currentSum = 0;
                for (int subRow = i; subRow < i + 3; subRow++)
                {
                    for (int subCol = j; subCol < j + 3; subCol++)
                    {
                        currentSum += matrix[subRow, subCol];
                    }
                }

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                    subRowIndex = i;
                    subColIndex = j;
                }
            }
        }

        // Print the MaxSubmatrix
        for (int i = subRowIndex; i < subRowIndex + 3; i++)
        {
            for (int j = subColIndex; j < subColIndex + 3; j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}