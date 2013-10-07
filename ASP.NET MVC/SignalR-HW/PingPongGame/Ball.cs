using System;
using System.Linq;

namespace PingPongGame
{
    public class Ball
    {
        private Coordinate center;

        public Ball(int x, int y)
        {
            this.center.X = x;
            this.center.Y = y;
        }

        public Coordinate Center
        {
            get
            {
                return this.center;
            }
            set
            {
                this.center = value;
            }
        }
    }
}