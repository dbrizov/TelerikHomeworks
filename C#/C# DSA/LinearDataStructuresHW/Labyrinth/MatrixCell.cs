using System;

namespace Labyrinth
{
    public class MatrixCell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Distance { get; set; }

        public MatrixCell(int row, int col, int distance)
        {
            this.Row = row;
            this.Col = col;
            this.Distance = distance;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MatrixCell))
            {
                return false;
            }

            MatrixCell objAsMatrixCoords = obj as MatrixCell;

            if (this.Row == objAsMatrixCoords.Row &&
                this.Col == objAsMatrixCoords.Col &&
                this.Distance == objAsMatrixCoords.Distance)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (this.Row ^ this.Col).GetHashCode();
        }
    }
}
