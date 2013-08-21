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
    public class SchoolsController : ApiController
    {
        private readonly IRepository<School> schoolRepository;

        public SchoolsController(IRepository<School> schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostSchool(School schoolEntity)
        {
            if (schoolEntity == null || schoolEntity.Name == null || schoolEntity.Location == null)
            {
                var errResponse =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The school is invalid");

                return errResponse;
            }

            try
            {
                var entity = this.schoolRepository.Add(schoolEntity);

                var response = this.Request.CreateResponse(
                    HttpStatusCode.Created, SchoolModel.CreateFromSchoolEntity(schoolEntity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.SchoolId }));

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The school could not be added because of a concurrency problem");
                return errResponse;
            }
        }

        [HttpGet]
        public SchoolModel Get(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the school must be positive");

                throw new HttpResponseException(errResponse);
            }

            var entity = this.schoolRepository.GetById(id);

            if (entity != null)
            {
                SchoolModel model = SchoolModel.CreateFromSchoolEntity(entity);
                return model;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<SchoolModel> GetAll()
        {
            var entities = this.schoolRepository.GetAll();

            List<SchoolModel> models = new List<SchoolModel>();
            foreach (var entity in entities)
            {
                models.Add(SchoolModel.CreateFromSchoolEntity(entity));
            }

            return models;
        }

        [HttpPut]
        public HttpResponseMessage PutSchool(int id, School schoolEntity)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the school must be positive");
                return errResponse;
            }

            try
            {
                var entity = this.schoolRepository.Update(id, schoolEntity);

                var response = this.Request.CreateResponse(
                    HttpStatusCode.OK, SchoolModel.CreateFromSchoolEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.SchoolId }));

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The school could not be updated because of a concurrency problem");

                return errResponse;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("A School entity with id={0} does not exist in the Database", id));

                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteSchool(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the student must be positive");
                return errResponse;
            }

            try
            {
                this.schoolRepository.Delete(id);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, "School deleted");
                return response;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    string.Format("A School entity with id={0} does not exist in the Database", id));

                return errResponse;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The school could not be deleted because of a concurrency problem");

                return errResponse;
            }
        }
    }
}
