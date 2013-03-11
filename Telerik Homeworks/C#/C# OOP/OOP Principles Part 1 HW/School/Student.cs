using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student : IPeople
    {
        // Fields
        private string name;
        private int numberInClass;

        // Constructors
        public Student()
        {
            name = string.Empty;
            numberInClass = 0;
        }

        public Student(string name, int numberInClass)
        {
            this.name = name;
            this.numberInClass = numberInClass;
        }

        public Student(Student student)
        {
            this.name = student.name;
            this.numberInClass = student.numberInClass;
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

        public int NumberInClass
        {
            get
            {
                return this.numberInClass;
            }
            set
            {
                this.numberInClass = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("{0}.{1}", this.numberInClass, this.name);
        }

        public void Live()
        {
            Console.WriteLine("Student - Live");
        }
    }
}
