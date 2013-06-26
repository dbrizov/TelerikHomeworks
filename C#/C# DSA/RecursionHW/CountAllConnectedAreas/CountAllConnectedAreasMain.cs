using System;

namespace CountAllConnectedAreas
{
    public class CountAllConnectedAreasMain
    {
        public static int connectedAreasCount = 0;

        public static char[,] labyrinth = 
            {
                {'-', '-', '-', '*', '-', '-', '-'},
                {'*', '*', '*', '*', '*', '*', '*'},
                {'-', '-', '*', '*', '-', '-', '-'},
                {'-', '*', '*', '*', '*', '*', '*'},
                {'-', '*', '-', '*', '-', '-', '-'},
            };

        public static void CountConnectedAreas()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == '-')
                    {
                        // If the cell is not visited, then the area is not visited.
                        MarkAreaAsVisited(i, j);
                        connectedAreasCount++;
                    }
                }
            }
        }

        public static void MarkAreaAsVisited(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth
                return;
            }

            if (labyrinth[row, col] == '-')
            {
                labyrinth[row, col] = 'v'; // Mark curent cell as visited

                // Recursively marks all empty neighbor cells as visited.
                // That way the whole area will be marked as visited
                MarkAreaAsVisited(row, col - 1); // Go left
                MarkAreaAsVisited(row, col + 1); // Go right
                MarkAreaAsVisited(row - 1, col); // Go up
                MarkAreaAsVisited(row + 1, col); // Go down
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
            CountConnectedAreas();
            Console.WriteLine("Number of connected areas: {0}", connectedAreasCount);
        }
    }
}
