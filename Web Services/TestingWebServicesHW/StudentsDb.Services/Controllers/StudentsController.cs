using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentsDb.DataLayer;
using StudentsDb.Repositories;
using StudentsDb.Services.Models;

namespace StudentsDb.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> studentRepository;

        public StudentsController(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostStudent(Student studentEntity)
        {
            if (studentEntity == null || studentEntity.FirstName == null ||
                studentEntity.LastName == null || studentEntity.School == null)
            {
                var errResponse =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The student is invalid");

                return errResponse;
            }

            try
            {
                var entity = this.studentRepository.Add(studentEntity);

                var response = this.Request.CreateResponse(
                    HttpStatusCode.Created, StudentModel.CreateFromStudentEntity(studentEntity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.StudentId }));

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The student could not be added because of a concurrency problem");
                return errResponse;
            }
        }

        [HttpGet]
        public StudentModel Get(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the student must be positive");

                throw new HttpResponseException(errResponse);
            }

            var entity = this.studentRepository.GetById(id);

            if (entity != null)
            {
                StudentModel model = StudentModel.CreateFromStudentEntity(entity);
                return model;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetAll()
        {
            var entities = this.studentRepository.GetAll();

            List<StudentModel> models = new List<StudentModel>();
            foreach (var entity in entities)
            {
                models.Add(StudentModel.CreateFromStudentEntity(entity));
            }

            return models;
        }

        [HttpGet]
        public IEnumerable<StudentModel> Find(string subject, double? value)
        {
            var entities = this.studentRepository
                .Find(s => s.Marks.Any(m => m.Subject == subject && m.Value >= value));

            List<StudentModel> models = new List<StudentModel>();
            foreach (var entity in entities)
            {
                models.Add(StudentModel.CreateFromStudentEntity(entity));
            }

            return models;
        }

        [HttpPut]
        public HttpResponseMessage PutStudent(int id, Student studentEntity)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the student must be positive");
                return errResponse;
            }

            try
            {
                var entity = this.studentRepository.Update(id, studentEntity);

                var response = this.Request.CreateResponse(
                    HttpStatusCode.OK, StudentModel.CreateFromStudentEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.StudentId }));

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The student could not be updated because of a concurrency problem");

                return errResponse;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("A Student entity with id={0} does not exist in the Database", id));

                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the student must be positive");
                return errResponse;
            }

            try
            {
                this.studentRepository.Delete(id);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, "Student deleted");
                return response;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    string.Format("A Student entity with id={0} does not exist in the Database", id));

                return errResponse;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The strudent could not be deleted because of a concurrency problem");

                return errResponse;
            }
        }
    }
}
