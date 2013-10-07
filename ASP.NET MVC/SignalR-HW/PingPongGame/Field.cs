using System;
using System.Linq;

namespace PingPongGame
{
    public class Field
    {
        private int width;
        private int height;

        public Field(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
    }
}