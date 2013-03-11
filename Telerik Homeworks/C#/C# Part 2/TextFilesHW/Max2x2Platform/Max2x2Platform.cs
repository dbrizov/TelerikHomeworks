using System;
using System.IO;

class Max2x2Platform
{
    static void Main(string[] args)
    {
        int matrixSize; // The size of the matrix. Example N x N
        int[,] matrix;

        StreamReader matrixReader = new StreamReader("matrix.txt");

        // Reads the file and generates the matrix
        using (matrixReader)
        {
            matrixSize = int.Parse(matrixReader.ReadLine());
            matrix = new int[matrixSize, matrixSize];

            string line = matrixReader.ReadLine();
            int row = 0;

            while (line != null)
            {
                string[] numbers = line.Split(' ');

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }

                line = matrixReader.ReadLine();
                row++;
            }
        }

        // Finds the max 2x2 platform
        int maxSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currentSum = 0;

                for (int platformRow = row; platformRow < row + 2; platformRow++)
                {
                    for (int platformCol = col; platformCol < col + 2; platformCol++)
                    {
                        currentSum += matrix[platformRow, platformCol];
                    }
                }

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        // Print the sum in a file
        StreamWriter sumWriter = new StreamWriter("max-2x2-platform-sum.txt");
        using (sumWriter)
        {
            sumWriter.WriteLine(maxSum);
        }
    }
}