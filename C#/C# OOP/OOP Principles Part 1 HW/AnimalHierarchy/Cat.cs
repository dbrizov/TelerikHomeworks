using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Cat : Animal
    {
        // Constructors
        public Cat() : base() { }
        public Cat(string name, int age, char sex) : base(name, age, sex) { }
        public Cat(Cat cat) : base((Animal)cat) { }

        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("Miauuuuuu!");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Cat\n");
            result.Append(string.Format("Name: {0}\nAge: {1}\nSex: {2}\n",
                this.Name, this.Age, this.Sex));

            return result.ToString();
        }
    }
}
