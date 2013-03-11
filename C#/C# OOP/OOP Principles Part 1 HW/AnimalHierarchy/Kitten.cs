using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Kitten : Cat
    {
        // Constructors
        public Kitten()
            : base()
        {
            this.sex = 'F';
        }
        public Kitten(string name, int age, char sex = 'F')
            : base(name, age, sex)
        {
            this.sex = 'F';
        }
        public Kitten(Kitten kitten) : base((Cat)kitten) { }

        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("\'Kitten miauuu\'!");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Kitten\n");
            result.Append(string.Format("Name: {0}\nAge: {1}\nSex: {2}\n",
                this.Name, this.Age, this.Sex));

            return result.ToString();
        }
    }
}
