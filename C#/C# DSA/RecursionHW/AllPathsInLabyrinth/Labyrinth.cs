using System;
using System.Collections.Generic;
using System.Text;

namespace AllPathsInLabyrinth
{
    public class Labyrinth
    {
        private const char PassableCell = '-';
        private const char NonPassableCell = '*';
        private const char StartCell = 'S';
        private const char EndCell = 'E';
        private const char VisitedCell = '☺';

        private int rows;
        private int cols;
        private char[,] labyrinth;
        private int startCellRow;
        private int startCellCol;
        private IList<char[,]> allPaths;

        public Labyrinth(char[,] labyrinth)
        {
            this.rows = labyrinth.GetLength(0);
            this.cols = labyrinth.GetLength(1);
            this.labyrinth = labyrinth;
            this.allPaths = new List<char[,]>();
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
        }

        public void SetStartCell(int row, int col)
        {
            if (!this.InRange(row, col))
            {
                throw new ArgumentException("The cell is out of the boundaries of the labyrinth");
            }

            if (this.labyrinth[row, col] == NonPassableCell)
            {
                throw new ArgumentException("The cell you chose is not empty");
            }

            this.labyrinth[row, col] = StartCell;
            this.startCellRow = row;
            this.startCellCol = col;
        }

        public void SetEndCell(int row, int col)
        {
            if (!this.InRange(row, col))
            {
                throw new ArgumentException("The cell is out of the boundaries of the labyrinth");
            }

            if (this.labyrinth[row, col] == NonPassableCell)
            {
                throw new ArgumentException("The cell you chose is not empty");
            }

            this.labyrinth[row, col] = EndCell;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    result.AppendFormat("{0, 3}", this.labyrinth[i, j]);
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        public IEnumerable<char[,]> FindAllPathBetweenTheStartAndEndCell()
        {
            this.FindAllPathBetweenTheStartAndEndCell(this.startCellRow, this.startCellCol);

            return this.allPaths;
        }

        private void FindAllPathBetweenTheStartAndEndCell(int row, int col)
        {
            if (!this.InRange(row, col) ||
                this.labyrinth[row, col] == NonPassableCell ||
                this.labyrinth[row, col] == VisitedCell)
            {
                // We are out of the labyrinth, 
                // we've stepped on a non-passable cell, or
                // we've stepped on an already visited cell
                return;
            }

            if (this.labyrinth[row, col] == EndCell)
            {
                // A path was found
                this.allPaths.Add((char[,])this.labyrinth.Clone());
            }
            else
            {
                this.labyrinth[row, col] = VisitedCell;

                FindAllPathBetweenTheStartAndEndCell(row, col - 1); // Go Left
                FindAllPathBetweenTheStartAndEndCell(row, col + 1); // Go Right
                FindAllPathBetweenTheStartAndEndCell(row - 1, col); // Go Up
                FindAllPathBetweenTheStartAndEndCell(row + 1, col); // Go Down

                this.labyrinth[row, col] = PassableCell;
            }
        }

        private bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < this.rows;
            bool colInRange = col >= 0 && col < this.cols;
            return rowInRange && colInRange;
        }
    }
}
