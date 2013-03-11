using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Frog : Animal
    {
        // Constructors
        public Frog() : base() { }
        public Frog(string name, int age, char sex) : base(name, age, sex) { }
        public Frog(Frog frog) : base((Animal)frog) { }

        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("Kvack kvack!");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Frog\n");
            result.Append(string.Format("Name: {0}\nAge: {1}\nSex: {2}\n",
                this.Name, this.Age, this.Sex));

            return result.ToString();
        }
    }
}
