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
    public class AlbumsController : ApiController
    {
        private readonly IRepository<Album> albumRepository;

        public AlbumsController(IRepository<Album> albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostAlbum(Album albumEntity)
        {
            if (albumEntity == null || albumEntity.Title == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The album is invalid");
                return errResponse;
            }

            try
            {
                var entity = this.albumRepository.Add(albumEntity);

                var response = this.Request.CreateResponse(HttpStatusCode.Created, AlbumModel.CreateFromAlbumEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.AlbumId }));
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The album could not be added because of a concurrency problem");
                return errResponse;
            }
        }

        [HttpGet]
        public AlbumModel GetById(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the album must be positive");
                throw new HttpResponseException(errResponse);
            }

            var entity = this.albumRepository.GetById(id);

            if (entity != null)
            {
                AlbumModel model = AlbumModel.CreateFromAlbumEntity(entity);
                return model;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<AlbumModel> GetAll()
        {
            var entities = this.albumRepository.GetAll();

            List<AlbumModel> models = new List<AlbumModel>();
            foreach (var entity in entities)
            {
                models.Add(AlbumModel.CreateFromAlbumEntity(entity));
            }

            return models;
        }

        [HttpPut]
        public HttpResponseMessage PutAlbum(int id, Album albumEntity)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the album must be positive");
                return errResponse;
            }

            try
            {
                var entity = this.albumRepository.Update(id, albumEntity);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, AlbumModel.CreateFromAlbumEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.AlbumId }));
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The album could not be updated because of a concurrency problem");
                return errResponse;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "There is no album with id=" + id);
                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAlbum(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the album must be positive");
                return errResponse;
            }

            try
            {
                this.albumRepository.Delete(id);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, "Album deleted");
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
