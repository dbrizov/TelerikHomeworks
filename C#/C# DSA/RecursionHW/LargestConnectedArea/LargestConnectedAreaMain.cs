using System;

namespace LargestConnectedArea
{
    public class LargestConnectedAreaMain
    {
        public static int maxConnectedAreaSize = 0;
        public static int connectedAreaSize = 0;

        public static char[,] labyrinth = 
            {
                {'-', '-', '-', '*', '-', '-', '-'},
                {'*', '*', '*', '*', '-', '*', '-'},
                {'-', '-', '*', '*', '-', '-', '-'},
                {'-', '*', '*', '*', '*', '*', '*'},
                {'-', '-', '-', '-', '-', '-', '-'},
            };

        public static void GetLargestConnectedAreaSize()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] != '*' && labyrinth[i, j] != 'v')
                    {
                        connectedAreaSize = 0;
                        GetConnectedAreaSize(i, j);
                    }
                }
            }
        }

        public static void GetConnectedAreaSize(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth
                return;
            }

            if (labyrinth[row, col] == '-')
            {
                labyrinth[row, col] = 'v'; // mark as visited

                connectedAreaSize++;
                if (maxConnectedAreaSize < connectedAreaSize)
                {
                    maxConnectedAreaSize = connectedAreaSize;
                }

                GetConnectedAreaSize(row, col - 1); // Go left
                GetConnectedAreaSize(row, col + 1); // Go right
                GetConnectedAreaSize(row - 1, col); // Go up
                GetConnectedAreaSize(row + 1, col); // Go down
            }
        }

        public static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool colInRange = col >= 0 && col < labyrinth.GetLength(1);
            return rowInRange && colInRange;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            PrintMatrix(labyrinth);
            GetLargestConnectedAreaSize();
            Console.WriteLine("The size of the largest connected area is {0}", maxConnectedAreaSize);
        }
    }
}
