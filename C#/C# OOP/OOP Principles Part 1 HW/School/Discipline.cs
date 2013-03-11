using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Discipline
    {
        // Fields
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        // Constructors
        public Discipline()
        {
            this.name = string.Empty;
            this.numberOfLectures = 0;
            this.numberOfExercises = 0;
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.name = name;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
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

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                this.numberOfExercises = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Name: {0}\nNumber of lectures: {1}\nNumber of exercises: {2}",
                this.name, this.numberOfLectures, this.numberOfExercises);
        }
    }
}
