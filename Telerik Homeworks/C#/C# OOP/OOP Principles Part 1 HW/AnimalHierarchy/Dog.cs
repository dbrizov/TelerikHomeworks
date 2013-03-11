using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Dog : Animal
    {
        // Constructors
        public Dog() : base() { }
        public Dog(string name, int age, char sex) : base(name, age, sex) { }
        public Dog(Dog dog) : base((Animal)dog) { }

        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("Bau bau!");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Dog\n");
            result.Append(string.Format("Name: {0}\nAge: {1}\nSex: {2}\n",
                this.Name, this.Age, this.Sex));

            return result.ToString();
        }
    }
}
