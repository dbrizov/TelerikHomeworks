using System;

namespace MatrixWalk
{
    public struct Direction
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Direction(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static bool operator ==(Direction direction1, Direction direction2)
        {
            if (direction1.Row == direction2.Row &&
                direction1.Col == direction2.Col)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Direction direction1, Direction direction2)
        {
            return !(direction1 == direction2);
        }
    }
}
