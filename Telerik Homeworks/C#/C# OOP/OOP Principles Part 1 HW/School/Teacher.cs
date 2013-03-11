using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Teacher : IPeople
    {
        // Fields
        private string name;
        private List<Discipline> disciplines;

        // Constructors
        public Teacher()
        {
            this.name = string.Empty;
            this.disciplines = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> disciplines)
        {
            this.name = name;
            this.disciplines = new List<Discipline>(disciplines);
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

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                this.disciplines = value;
            }
        }

        // Methods
        public void AddDiscipline(Discipline discipline)
        {
            if (this.disciplines.Contains(discipline) == false)
            {
                this.disciplines.Add(discipline);
            }
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }

        public void Live()
        {
            Console.WriteLine("Teacher - Live");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("Teacher: {0}\nDisciplines:\n", this.name));
            for (int i = 0; i < this.disciplines.Count; i++)
            {
                result.Append(string.Format("{0}\n", this.disciplines[i]));
            }

            return result.ToString();
        }

        // Predefined operators
        public static bool operator ==(Teacher teacher1, Teacher teacher2)
        {
            bool equalDisciplines = true;
            bool equalNames = true;

            // check for equal disciplines
            if (teacher1.Disciplines.Count != teacher2.Disciplines.Count)
            {
                equalDisciplines = false;
            }
            else if (teacher1.Disciplines.Count == teacher2.Disciplines.Count)
            {
                for (int i = 0; i < teacher1.Disciplines.Count; i++)
                {
                    if (teacher1.Disciplines[i] != teacher2.Disciplines[i])
                    {
                        equalDisciplines = false;
                    }
                }
            }

            // chack for equal names
            if (teacher1.Name != teacher2.Name)
            {
                equalNames = false;
            }

            return equalNames && equalDisciplines;
        }

        public static bool operator !=(Teacher teacher1, Teacher teacher2)
        {
            return !(teacher1 == teacher2);
        }
    }
}
