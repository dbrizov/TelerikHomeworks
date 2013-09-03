using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.Data
{
    public class InMemoryStudentsData
    {
        public IList<Student> Students { get; set; }

        public InMemoryStudentsData(int count)
        {
            this.Students = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                Student newStudent = new Student()
                {
                    Grade = i,
                    Id = i,
                    Name = "Student#" + i
                };

                int marksCount = i + 1;
                var marks = new List<Mark>();
                for (int j = 0; j < marksCount; j++)
                {
                    var newMark = new Mark()
                    {
                        Subject = "Mark#" + j,
                        Score = j
                    };

                    marks.Add(newMark);
                }

                newStudent.Marks = marks;
                this.Students.Add(newStudent);
            }
        }
    }
}
