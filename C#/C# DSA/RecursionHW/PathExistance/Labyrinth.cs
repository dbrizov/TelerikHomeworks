using System;
using System.Collections.Generic;
using System.Text;

namespace PathExistance
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

        public Labyrinth(char[,] labyrinth)
        {
            this.rows = labyrinth.GetLength(0);
            this.cols = labyrinth.GetLength(1);
            this.labyrinth = labyrinth;
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

        public bool ExistsPathBetweenTheStartAndEndCells()
        {
            return this.ExistsPathBetweenTheStartAndEndCells(this.startCellRow, this.startCellCol);
        }

        private bool ExistsPathBetweenTheStartAndEndCells(int row, int col)
        {
            if (!this.InRange(row, col) ||
                this.labyrinth[row, col] == NonPassableCell ||
                this.labyrinth[row, col] == VisitedCell)
            {
                // We are out of the labyrinth, 
                // we've stepped on a non-passable cell, or
                // we've stepped on an already visited cell
                return false;
            }

            if (this.labyrinth[row, col] == EndCell)
            {
                // A path was found
                return true;
            }
            else
            {
                bool existsPath = false;
                this.labyrinth[row, col] = VisitedCell;

                existsPath = ExistsPathBetweenTheStartAndEndCells(row, col - 1) ||
                             ExistsPathBetweenTheStartAndEndCells(row, col + 1)|| 
                             ExistsPathBetweenTheStartAndEndCells(row - 1, col) ||
                             ExistsPathBetweenTheStartAndEndCells(row + 1, col);

                this.labyrinth[row, col] = PassableCell;

                return existsPath;
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
