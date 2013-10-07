using System;
using System.Linq;

namespace PingPongGame
{
    public class PlayerPad
    {
        private Coordinate topLeft;
        private int size;

        public PlayerPad(int x, int y, int size)
        {
            this.topLeft.X = x;
            this.topLeft.Y = y;
            this.size = size;
        }

        public Coordinate TopLeft
        {
            get
            {
                return this.topLeft;
            }
            set
            {
                this.topLeft = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}