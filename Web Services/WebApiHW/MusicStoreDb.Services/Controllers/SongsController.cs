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
    public class SongsController : ApiController
    {
        private readonly IRepository<Song> songRepository;

        public SongsController(IRepository<Song> songRepository)
        {
            this.songRepository = songRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostSong(Song songEntity)
        {
            if (songEntity == null || songEntity.Title == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The song is invalid");
                return errResponse;
            }

            try
            {
                var entity = this.songRepository.Add(songEntity);

                var response = this.Request.CreateResponse(HttpStatusCode.Created, SongModel.CreateFromSongEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.SongId }));
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The song could not be added because of a concurrency problem");
                return errResponse;
            }
        }

        [HttpGet]
        public SongModel GetById(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the song must be positive");
                throw new HttpResponseException(errResponse);
            }

            var entity = this.songRepository.GetById(id);

            if (entity != null)
            {
                SongModel model = SongModel.CreateFromSongEntity(entity);
                return model;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<SongModel> GetAll()
        {
            var entities = this.songRepository.GetAll();

            List<SongModel> models = new List<SongModel>();
            foreach (var entity in entities)
            {
                models.Add(SongModel.CreateFromSongEntity(entity));
            }

            return models;
        }

        [HttpPut]
        public HttpResponseMessage PutSong(int id, Song songEntity)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the song must be positive");
                return errResponse;
            }

            try
            {
                var entity = this.songRepository.Update(id, songEntity);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, SongModel.CreateFromSongEntity(entity));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.SongId }));
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The song could not be updated because of a concurrency problem");
                return errResponse;
            }
            catch (NullReferenceException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "There is no song with id=" + id);
                return errResponse;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteSong(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "The id of the song must be positive");
                return errResponse;
            }

            try
            {
                this.songRepository.Delete(id);

                var response = this.Request.CreateResponse(HttpStatusCode.OK, "Song deleted");
                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "The song could not be deleted because of a concurrency problem");
                return errResponse;
            }
        }
    }
}
