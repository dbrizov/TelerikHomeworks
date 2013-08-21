using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStoreDb.DataLayer;
using MusicStoreDb.Repositories;
using MusicStoreDb.Services.Models;

namespace MusicStoreDb.Services.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IRepository<Artist> artistRepository;

        public ArtistsController(IRepository<Artist> artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostArtist(Artist artistEntity)
        {
            if (artistEntity == null || artistEntity.Name == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The artist is invalid");
                return errResponse;
            }

            try
            {
                var entity = this.artistRepository.Add(artistEntity);

                var response = this.Request.CreateResponse(HttpStatusCode.Created, ArtistModel.CreateFromArtistEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.ArtistsId }));
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The artist could not be added because of a concurrency problem");
                return errResponse;
            }
        }

        [HttpGet]
        public ArtistModel GetById(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the artist must be positive");
                throw new HttpResponseException(errResponse);
            }

            var entity = this.artistRepository.GetById(id);

            if (entity != null)
            {
                ArtistModel model = ArtistModel.CreateFromArtistEntity(entity);
                return model;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<ArtistModel> GetAll()
        {
            var entities = this.artistRepository.GetAll();

            List<ArtistModel> models = new List<ArtistModel>();
            foreach (var entity in entities)
            {
                models.Add(ArtistModel.CreateFromArtistEntity(entity));
            }

            return models;
        }

        [HttpPut]
        public HttpResponseMessage PutArtist(int id, Artist artistEntity)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the artist must be positive");
                return errResponse;
            }

            try
            {
                var entity = this.artistRepository.Update(id, artistEntity);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, ArtistModel.CreateFromArtistEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.ArtistsId }));
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The artist could not be updated because of a concurrency problem");
                return errResponse;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "There is no artist with id=" + id);
                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteArtist(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the album must be positive");
                return errResponse;
            }

            try
            {
                this.artistRepository.Delete(id);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, "Artist deleted");
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The album could not be deleted because of a concurrency problem");
                return errResponse;
            }
        }
    }
}
