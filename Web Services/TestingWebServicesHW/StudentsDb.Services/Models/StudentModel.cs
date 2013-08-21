using System;
using System.Linq;
using StudentsDb.DataLayer;

namespace StudentsDb.Services.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Nullable<double> Grade { get; set; }

        public int SchoolId { get; set; }

        public static StudentModel CreateFromStudentEntity(Student entity)
        {
            StudentModel model = new StudentModel()
            {
                Id = entity.StudentId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Grade = entity.Grade,
                SchoolId = entity.SchoolId
            };

            return model;
        }
    }
}