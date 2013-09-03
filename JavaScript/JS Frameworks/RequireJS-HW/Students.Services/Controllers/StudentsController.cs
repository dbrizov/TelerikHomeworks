using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Students.Data;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly InMemoryStudentsData data;

        public StudentsController()
        {
            this.data = new InMemoryStudentsData(20);
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetAll()
        {
            var students = this.data.Students.Select(StudentModel.FromStudent);
            return students;
        }

        [HttpGet]
        [ActionName("marks")]
        public IEnumerable<MarkModel> GetMarksOfStudent([FromUri] int studentId)
        {
            try
            {
                var student = this.data.Students[studentId];
                var marks = student.Marks.Select(MarkModel.FromMark);
                return marks;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException(
                    string.Format("A student with id={0} does not exist", studentId), ex);
            }
        }
    }
}
