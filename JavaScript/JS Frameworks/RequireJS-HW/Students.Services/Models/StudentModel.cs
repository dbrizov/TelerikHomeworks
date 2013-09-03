using System;
using System.Linq;
using System.Runtime.Serialization;
using Students.Data;

namespace Students.Services.Models
{
    [DataContract]
    public class StudentModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        public static Func<Student, StudentModel> FromStudent
        {
            get
            {
                return st => new StudentModel()
                {
                    Id = st.Id,
                    Name = st.Name,
                    Grade = st.Grade
                };
            }
        }
    }
}