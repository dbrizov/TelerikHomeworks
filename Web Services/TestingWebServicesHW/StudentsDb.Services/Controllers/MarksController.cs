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
    public class MarksController : ApiController
    {
        private readonly IRepository<Mark> markRepository;

        public MarksController(IRepository<Mark> markRepository)
        {
            this.markRepository = markRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostMark(Mark markEntity)
        {
            if (markEntity == null || markEntity.Subject == null || markEntity.Value == null)
            {
                var errResponse =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The mark is invalid");

                return errResponse;
            }

            try
            {
                var entity = this.markRepository.Add(markEntity);

                var response = this.Request.CreateResponse(
                    HttpStatusCode.Created, MarkModel.CreateFromMarkEntity(markEntity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.MarkId }));

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The mark could not be added because of a concurrency problem");
                return errResponse;
            }
        }

        [HttpGet]
        public MarkModel Get(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the mark must be positive");

                throw new HttpResponseException(errResponse);
            }

            var entity = this.markRepository.GetById(id);

            if (entity != null)
            {
                MarkModel model = MarkModel.CreateFromMarkEntity(entity);
                return model;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<MarkModel> GetAll()
        {
            var entities = this.markRepository.GetAll();

            List<MarkModel> models = new List<MarkModel>();
            foreach (var entity in entities)
            {
                models.Add(MarkModel.CreateFromMarkEntity(entity));
            }

            return models;
        }

        [HttpPut]
        public HttpResponseMessage PutMark(int id, Mark markEntity)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the mark must be positive");
                return errResponse;
            }

            try
            {
                var entity = this.markRepository.Update(id, markEntity);

                var response = this.Request.CreateResponse(
                    HttpStatusCode.OK, MarkModel.CreateFromMarkEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.MarkId }));

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The mark could not be updated because of a concurrency problem");

                return errResponse;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("A Mark entity with id={0} does not exist in the Database", id));

                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteMark(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the mark must be positive");
                return errResponse;
            }

            try
            {
                this.markRepository.Delete(id);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, "Mark deleted");
                return response;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    string.Format("A Mark entity with id={0} does not exist in the Database", id));

                return errResponse;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The mark could not be deleted because of a concurrency problem");

                return errResponse;
            }
        }
    }
}
