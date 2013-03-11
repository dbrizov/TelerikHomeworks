using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class StudentsClass
    {
        // Fields
        private List<Student> students;
        private List<Teacher> teachers;
        private string uniqueTextIdentifier;

        // Constructors
        public StudentsClass()
        {
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
            this.uniqueTextIdentifier = string.Empty;
        }

        public StudentsClass(List<Student> students, List<Teacher> teachers, string uniqueTextIdentifier)
        {
            this.students = new List<Student>(students);
            this.teachers = new List<Teacher>(teachers);
            this.uniqueTextIdentifier = uniqueTextIdentifier;
        }

        // Properties
        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }
        }

        public string UniqueTextIdentifier
        {
            get
            {
                return this.uniqueTextIdentifier;
            }
            set
            {
                this.uniqueTextIdentifier = value;
            }
        }

        // Methods
        public void AddStudent(Student student)
        {
            foreach (Student stud in this.students)
            {
                if (stud.NumberInClass == student.NumberInClass)
                {
                    return;
                }
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                if (this.students[i].Name == student.Name &&
                    this.students[i].NumberInClass == student.NumberInClass)
                {
                    this.students.RemoveAt(i);
                    return;
                }
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            foreach (Teacher teach in this.teachers)
            {
                if (teach.Disciplines == teacher.Disciplines &&
                    teach.Name == teacher.Name)
                {
                    return;
                }
            }

            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            for (int i = 0; i < this.teachers.Count; i++)
            {
                if (this.teachers[i] == teacher)
                {
                    this.teachers.RemoveAt(i);
                    return;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Identifier: {0}\n", this.uniqueTextIdentifier));
            result.Append("Students:\n");

            for (int i = 0; i < this.students.Count; i++)
            {
                result.Append(string.Format("{0}\n", this.students[i]));
            }

            result.Append("Teachers:\n");

            for (int i = 0; i < this.teachers.Count; i++)
            {
                result.Append(string.Format("{0}\n", this.teachers[i]));
            }

            return result.ToString();
        }
    }
}
