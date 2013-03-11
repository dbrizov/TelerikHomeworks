using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartOne
{
    // Pair for the display size
    struct Pair
    {
        public int width;
        public int height;

        public Pair(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
        }
    }

    // Exercise 1 - define class Display
    class Display
    {
        // Private:
        private Pair size;
        private int numberOfColors;

        // Exercise 2 - define several constructors
        // Public:
        public Display()
        {
            this.size.width = 0;
            this.size.height = 0;
            this.numberOfColors = 0;
        }

        public Display(Pair size, int numberOfColors = 0)
        {
            this.size.width = size.width;
            this.size.height = size.height;
            this.numberOfColors = numberOfColors;
        }

        // Exercise 4 - override ToString()
        public override string ToString()
        {
            return "Display: " + "\n  width: " + this.size.width +
                                 "\n  height: " + this.size.height +
                                 "\n  number of colors: " + this.numberOfColors;
        }

        // Exercise 5 - encapsulate data fields
        public Pair Size
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

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value < 2)
                {
                    throw new ArgumentException("The mimimum number of colors 2");
                }

                this.numberOfColors = value;
            }
        }
    }
}
