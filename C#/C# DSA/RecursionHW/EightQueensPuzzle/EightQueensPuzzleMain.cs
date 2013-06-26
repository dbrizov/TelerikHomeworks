using System;

namespace EightQueensPuzzle
{
    public class EightQueensPuzzleMain
    {
        private static int size = 8;
        private static int[,] table = new int[size, size];
        private static int solutionsCount = 0;

        public static void MarkAllAttackedPositons(int row, int col)
        {
            // Mark the vertical
            for (int i = 0; i < size; i++)
            {
                table[i, col]++;
            }

            // Mark the horizontal
            for (int i = col; i < size; i++)
            {
                table[row, i]++;
            }

            int currentRow = row;
            int currentCol = col;

            // Mark the diagonals
            while (currentRow >= 0 && currentCol < size)
            {
                table[currentRow, currentCol]++;
                currentRow--;
                currentCol++;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow < size && currentCol < size)
            {
                table[currentRow, currentCol]++;
                currentRow++;
                currentCol++;
            }
        }

        public static void UnmarkAllAttackedPositions(int row, int col)
        {
            // Unmark the vertical
            for (int i = 0; i < size; i++)
            {
                table[i, col]--;
            }

            // Unmark the horizontal
            for (int i = col; i < size; i++)
            {
                table[row, i]--;
            }

            int currentRow = row;
            int currentCol = col;

            // Unmark the diagonals
            while (currentRow >= 0 && currentCol < size)
            {
                table[currentRow, currentCol]--;
                currentRow--;
                currentCol++;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow < size && currentCol < size)
            {
                table[currentRow, currentCol]--;
                currentRow++;
                currentCol++;
            }
        }

        public static bool CanPlaceQueen(int row, int col)
        {
            return table[row, col] == 0;
        }

        public static void PlaceQueens(int col)
        {
            if (col == size)
            {
                solutionsCount++;
            }
            else
            {
                for (int row = 0; row < size; row++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositons(row, col);
                        PlaceQueens(col + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            PlaceQueens(0);
            Console.WriteLine(solutionsCount);
        }
    }
}
