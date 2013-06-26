using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class LabyrinthMain
    {
        public static string[,] GenerateLabyrinth(int size)
        {
            Random randomGenerator = new Random();
            string[,] labyrinth = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int cellValue = randomGenerator.Next(3);
                    switch (cellValue)
                    {
                        case 0:
                            labyrinth[i, j] = "-";
                            break;
                        case 1:
                            labyrinth[i, j] = "0";
                            break;
                        case 2:
                            labyrinth[i, j] = "0";
                            break;
                    }
                }
            }

            return labyrinth;
        }

        public static void PrintLabyrinth<T>(T[,] matrix)
        {
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void SearchLabyrinth(string[,] labyrinth, int startRow, int startCol)
        {
            MatrixCell startCell = new MatrixCell(startRow, startCol, 0);

            Queue<MatrixCell> queue = new Queue<MatrixCell>();
            queue.Enqueue(startCell);

            List<MatrixCell> searchedCells = new List<MatrixCell>();
            searchedCells.Add(startCell);

            int labyrinthMaxRow = labyrinth.GetLength(0) - 1;
            int labyrinthMaxCol = labyrinth.GetLength(1) - 1;

            // Fill up the reacheable empty cells with the current distance reached
            while (queue.Count > 0)
            {
                MatrixCell currentCell = queue.Dequeue();
                int currRow = currentCell.Row;
                int currCol = currentCell.Col;
                int currDistance = currentCell.Distance;
                labyrinth[currRow, currCol] = currDistance.ToString();

                // check the upper cell
                if (currRow != 0) // The upper cell is not out of range
                {
                    MatrixCell upperCell = new MatrixCell(currRow - 1, currCol, currDistance + 1);

                    if (labyrinth[upperCell.Row, upperCell.Col] == "0" &&
                        !searchedCells.Contains(upperCell))
                    {
                        // The upper cell is empty and wasn't searched yet
                        queue.Enqueue(upperCell);
                        searchedCells.Add(upperCell);
                    }
                }

                // check the right cell
                if (currCol != labyrinthMaxCol) // The right cell is not out of range
                {
                    MatrixCell rightCell = new MatrixCell(currRow, currCol + 1, currDistance + 1);

                    if (labyrinth[rightCell.Row, rightCell.Col] == "0" &&
                        !searchedCells.Contains(rightCell))
                    {
                        // The right cell is empty and wasn't searched yet
                        queue.Enqueue(rightCell);
                        searchedCells.Add(rightCell);
                    }
                }

                // check the lower cell
                if (currRow != labyrinthMaxRow) // The lower cell is not out of range
                {
                    MatrixCell lowerCell = new MatrixCell(currRow + 1, currCol, currDistance + 1);

                    if (labyrinth[lowerCell.Row, lowerCell.Col] == "0" &&
                        !searchedCells.Contains(lowerCell))
                    {
                        // The lower cell is empty and wasn't searched yet
                        queue.Enqueue(lowerCell);
                        searchedCells.Add(lowerCell);
                    }
                }

                // check the left cell
                if (currCol != 0) // The left cell is not out of range
                {
                    MatrixCell leftCell = new MatrixCell(currRow, currCol - 1, currDistance + 1);
                    if (labyrinth[leftCell.Row, leftCell.Col] == "0" &&
                        !searchedCells.Contains(leftCell))
                    {
                        // The left cell is empty and wasn't searched yet
                        queue.Enqueue(leftCell);
                        searchedCells.Add(leftCell);
                    }
                }
            }

            // Fill up the startCell with *
            labyrinth[startRow, startCol] = "*";

            // Fill up the unreached empty cells
            for (int i = 0; i <= labyrinthMaxRow; i++)
            {
                for (int j = 0; j <= labyrinthMaxCol; j++)
                {
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = "u";
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Labyrinth size = ");
            int labyrinthSize = int.Parse(Console.ReadLine());

            string[,] labyrinth = GenerateLabyrinth(labyrinthSize);

            PrintLabyrinth(labyrinth);

            bool cellIsFull = true;
            int startRow;
            int startCol;

            do
            {
                Console.Write("Choose empty cell row: ");
                startRow = int.Parse(Console.ReadLine());

                Console.Write("Choose empty cell column: ");
                startCol = int.Parse(Console.ReadLine());

                if (labyrinth[startRow, startCol] != "-")
                {
                    cellIsFull = false;
                    break;
                }

                Console.WriteLine("The cell is full");
            }
            while (cellIsFull);

            SearchLabyrinth(labyrinth, startRow, startCol);

            PrintLabyrinth(labyrinth);
        }
    }
}
