using System;
using System.Data.Entity;
using System.Linq;
using MusicStoreDb.DataLayer;

namespace MusicStoreDb.Repositories
{
    public class DbSongRepository : IRepository<Song>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Song> entitySet;

        public DbSongRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Song>();
        }

        public Song Add(Song item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Song GetById(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Song> GetAll()
        {
            return this.entitySet;
        }

        public Song Update(int id, Song item)
        {
            Song songEntity = this.entitySet.Find(id);
            songEntity.AlbumId = item.AlbumId;
            songEntity.ArtistId = item.ArtistId;
            songEntity.Genre = item.Genre;
            songEntity.Title = item.Title;
            songEntity.Year = item.Year;

            this.dbContext.SaveChanges();

            return songEntity;
        }

        public void Delete(int id)
        {
            Song songEntity = this.entitySet.Find(id);
            if (songEntity != null)
            {
                this.entitySet.Remove(songEntity);
                this.dbContext.SaveChanges();
            }
        }
    }
}
