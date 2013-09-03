using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        [HttpGet]
        public IEnumerable<StudentModel> GetAll()
        {
            var students = this.GenerateStudents();
            return students;
        }

        private IEnumerable<StudentModel> GenerateStudents()
        {
            MarkModel mark1 = new MarkModel()
            {
                Subject = "Math",
                Score = 3
            };

            MarkModel mark2 = new MarkModel()
            {
                Subject = "JavaScript",
                Score = 6
            };

            MarkModel mark3 = new MarkModel()
            {
                Subject = "C#",
                Score = 6
            };

            List<StudentModel> students = new List<StudentModel>()
            {
                new StudentModel()
                {
                    FirstName = "Doncho",
                    LastName = "Minkvo",
                    age = 23,
                    grade = 4,
                    Marks = new List<MarkModel>() { mark1, mark2 }
                },

                new StudentModel()
                {
                    FirstName = "Niki",
                    LastName = "Kostov",
                    age = 22,
                    grade = 4,
                    Marks = new List<MarkModel>() { mark1, mark3 }
                },

                new StudentModel()
                {
                    FirstName = "Ivaylo",
                    LastName = "Kenov",
                    age = 22,
                    grade = 4,
                    Marks = new List<MarkModel>() { mark1, mark2, mark3 }
                }
            };

            return students;
        }
    }
}
