using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Tomcat : Cat
    {
        // Constructors
        public Tomcat() : base()
        {
            this.sex = 'M';
        }
        public Tomcat(string name, int age, char sex = 'M')
            : base(name, age, sex)
        {
            this.sex = 'M';
        }
        public Tomcat(Tomcat tomcat) : base((Cat)tomcat) { }

        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("\'Tomcat miauuu\'!");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Tomcat\n");
            result.Append(string.Format("Name: {0}\nAge: {1}\nSex: {2}\n",
                this.Name, this.Age, this.Sex));

            return result.ToString();
        }
    }
}
