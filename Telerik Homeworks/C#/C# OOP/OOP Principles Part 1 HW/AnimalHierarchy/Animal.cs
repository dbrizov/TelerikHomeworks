using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Animal : ISound
    {
        // Fields
        protected string name;
        protected int age;
        protected char sex; // only F and M

        // Constructors
        public Animal()
        {
            this.name = string.Empty;
            this.age = 0;
            this.sex = ' ';
        }

        public Animal(string name, int age, char sex)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }

        public Animal(Animal animal)
        {
            this.name = animal.name;
            this.age = animal.age;
            this.sex = animal.sex;
        }

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public char Sex
        {
            get
            {
                return this.sex;
            }
        }

        // Methods
        public virtual void MakeSound()
        {
            Console.WriteLine("unknown sound");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Animal\n");
            result.Append(string.Format("Name: {0}\nAge: {1}\nSex: {2}\n",
                this.name, this.age, this.sex));

            return result.ToString();
        }
    }
}
