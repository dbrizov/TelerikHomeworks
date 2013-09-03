using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Students.Services.Models
{
    [DataContract]
    public class StudentModel
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "grade")]
        public int grade { get; set; }

        [DataMember(Name = "age")]
        public int age { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<MarkModel> Marks { get; set; }
    }
}