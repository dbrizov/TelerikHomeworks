using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_1_2_3
{
    public class Student : ICloneable, IComparable<Student>
    {
        // Constructors
        public Student() : this("") { } // Calls the second constructor

        public Student(
            string firstName = "", string middleName = "", string lastName = "",
            string ssn = "", string address = "", string mobileNumber = "",
            string email = "", byte course = 0, Specialties specialty = Specialties.Undefined,
            Universities university = Universities.Undefined, Faculties faculty = Faculties.Undefined)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobileNumber = mobileNumber;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        // Properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public byte Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        // Methods
        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                return false;
            }

            Student student = (Student)obj;

            if (this.FirstName != student.FirstName)
            {
                return false;
            }

            if (this.MiddleName != student.MiddleName)
            {
                return false;
            }

            if (this.LastName != student.LastName)
            {
                return false;
            }

            if (this.SSN != student.SSN)
            {
                return false;
            }

            if (this.Address != student.Address)
            {
                return false;
            }

            if (this.MobileNumber != student.MobileNumber)
            {
                return false;
            }

            if (this.Email != student.Email)
            {
                return false;
            }

            if (this.Course != student.Course)
            {
                return false;
            }

            if (this.Specialty != student.Specialty)
            {
                return false;
            }

            if (this.University != student.University)
            {
                return false;
            }

            if (this.Faculty != student.Faculty)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            // I return only the SSN hash code because every student has a unique SSN
            return this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("First name: {0}\n", this.FirstName));
            result.Append(string.Format("Middle name: {0}\n", this.MiddleName));
            result.Append(string.Format("Last name: {0}\n", this.LastName));
            result.Append(string.Format("SSN: {0}\n", this.SSN));
            result.Append(string.Format("Address: {0}\n", this.Address));
            result.Append(string.Format("Mobile number: {0}\n", this.MobileNumber));
            result.Append(string.Format("Email: {0}\n", this.Email));
            result.Append(string.Format("Course: {0}\n", this.Course));
            result.Append(string.Format("Specialty: {0}\n", this.Specialty));
            result.Append(string.Format("University: {0}\n", this.University));
            result.Append(string.Format("Faculty: {0}\n", this.Faculty));

            return result.ToString();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Object.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !Object.Equals(firstStudent, secondStudent);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN,
                this.Address, this.MobileNumber, this.Email, this.Course, this.Specialty,
                this.University, this.Faculty);
        }

        public int CompareTo(Student st)
        {
            string firstStudent = string.Format("{0}{1}{2}{3}", this.FirstName, this.MiddleName, this.LastName, this.SSN);

            string secondStudent = string.Format("{0}{1}{2}{3}", st.FirstName, st.MiddleName, st.LastName, st.SSN);

            return firstStudent.CompareTo(secondStudent);
        }
    }
}
