using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorChef
{
    public class Chef
    {
        public Bowl GetBowl()
        {
            return new Bowl();
        }

        public Potato GetPotato()
        {
            return new Potato();
        }

        public Carrot GetCarrot()
        {
            return new Carrot();
        }

        public void Cut(IFood food)
        {
            Console.WriteLine(food.ToString() + " has been cut");
        }

        public void Peel(IFood food)
        {
            Console.WriteLine(food.ToString() + " has been peeled");
        }

        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            bowl.Add(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);
        }
    }
}
