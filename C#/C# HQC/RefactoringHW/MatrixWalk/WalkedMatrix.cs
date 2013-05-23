using System;
using System.Text;

namespace MatrixWalk
{
    public class WalkedMatrix
    {
        private static readonly Direction[] Directions = 
        {
            new Direction(1, 1), // down-right
            new Direction(1, 0), // down
            new Direction(1, -1), // down-left
            new Direction(0, -1), // left
            new Direction(-1, -1), // up-left
            new Direction(-1, 0), // up
            new Direction(-1, 1), // up-right
            new Direction(0, 1) // right
        };

        private int[,] matrix;

        public WalkedMatrix(int rowsCount, int colsCount)
        {
            this.matrix = new int[rowsCount, colsCount];

            int cellValue = 0;
            int currentRow = 0;
            int currentCol = 0;
            Direction currentDirection = new Direction(1, 1); // down-right

            FillUpTheMatrixEmptyCells(this.matrix, ref cellValue, ref currentRow, ref currentCol, ref currentDirection);

            if (MatrixHasEmptyCells(this.matrix))
            {
                FindEmptyCellWithMinRowAndCol(this.matrix, ref currentRow, ref currentCol);

                currentDirection = new Direction(1, 1); // down-right

                FillUpTheMatrixEmptyCells(this.matrix, ref cellValue, ref currentRow, ref currentCol, ref currentDirection);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    result.AppendFormat("{0,5}", this.matrix[i, j]);
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        private static void ChangeDirection(ref Direction currentDirection)
        {
            Direction[] directions = (Direction[])WalkedMatrix.Directions.Clone();
            int currentDirectionIndex = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == currentDirection)
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            // if currenDirection == right
            if (currentDirection == directions[7])
            {
                currentDirection = directions[0]; // currentDirection = down-right
                return;
            }

            currentDirection = directions[currentDirectionIndex + 1];
        }

        private static bool ThereIsEmptyNeighbourCell(int[,] arr, int currentRow, int currentCol)
        {
            Direction[] directions = (Direction[])WalkedMatrix.Directions.Clone();

            for (int i = 0; i < directions.Length; i++)
            {
                if (currentRow + directions[i].Row >= arr.GetLength(0) ||
                    currentRow + directions[i].Row < 0)
                {
                    directions[i].Row = 0;
                }

                if (currentCol + directions[i].Col >= arr.GetLength(1) ||
                    currentCol + directions[i].Col < 0)
                {
                    directions[i].Col = 0;
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                if (arr[currentRow + directions[i].Row, currentCol + directions[i].Col] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindEmptyCellWithMinRowAndCol(int[,] arr, ref int currentRow, ref int currentCol)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        currentRow = i;
                        currentCol = j;
                        return;
                    }
                }
            }
        }

        private static bool NextCellIsEmpty(int[,] arr, int currentRow, int currentCol, Direction currentDirection)
        {
            bool isOutOfMatrixBoundaries =
                currentRow + currentDirection.Row >= arr.GetLength(0) ||
                currentRow + currentDirection.Row < 0 ||
                currentCol + currentDirection.Col >= arr.GetLength(1) ||
                currentCol + currentDirection.Col < 0;

            if (isOutOfMatrixBoundaries)
            {
                return false;
            }

            bool isEmptyCell =
                arr[currentRow + currentDirection.Row, currentCol + currentDirection.Col] == 0;

            return isEmptyCell;
        }

        private static bool MatrixHasEmptyCells(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FillUpTheMatrixEmptyCells(int[,] arr,
                                                      ref int cellValue,
                                                      ref int currentRow,
                                                      ref int currentCol,
                                                      ref Direction currentDirection)
        {
            int previousRow = 0;
            int previousCol = 0;

            do
            {
                cellValue++;
                arr[currentRow, currentCol] = cellValue;

                while (ThereIsEmptyNeighbourCell(arr, currentRow, currentCol) &&
                       !NextCellIsEmpty(arr, currentRow, currentCol, currentDirection))
                {
                    ChangeDirection(ref currentDirection);
                }

                previousRow = currentRow;
                previousCol = currentCol;
                currentRow += currentDirection.Row;
                currentCol += currentDirection.Col;
            }
            while (ThereIsEmptyNeighbourCell(arr, previousRow, previousCol));
        }
    }
}
