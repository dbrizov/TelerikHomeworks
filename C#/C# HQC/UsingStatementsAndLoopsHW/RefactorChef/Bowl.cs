using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactorChef
{
    public class Bowl
    {
        private List<IFood> content;
        private double diameter;

        public Bowl()
        {
            this.content = new List<IFood>();
            this.diameter = 0;
        }

        public Bowl(double diameter)
        {
            this.content = new List<IFood>();
            this.diameter = diameter;
        }

        public Bowl(double diameter, List<IFood> content)
        {
            this.content = new List<IFood>(content);
            this.diameter = diameter;
        }

        public double Diameter
        {
            get
            {
                return this.diameter;
            }

            set
            {
                if (value < 0)
                {
                    this.diameter = value;
                }
                else
                {
                    throw new ArgumentException("the diameter of the bowl must be > 0");
                }
            }
        }

        public List<IFood> Content
        {
            get
            {
                return new List<IFood>(this.content);
            }

            set
            {
                this.content = new List<IFood>(value);
            }
        }

        public void Add(IFood food)
        {
            this.content.Add(food);
        }
    }
}
