using System;
using System.Data.Entity;
using System.Linq;
using MusicStoreDb.DataLayer;

namespace MusicStoreDb.Repositories
{
    public class DbAlbumRepository : IRepository<Album>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Album> entitySet;

        public DbAlbumRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Album>();
        }

        public Album Add(Album item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Album GetById(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Album> GetAll()
        {
            return this.entitySet;
        }

        public Album Update(int id, Album item)
        {
            Album albumEntity = this.entitySet.Find(id);
            albumEntity.Artists = item.Artists;
            albumEntity.Producer = item.Producer;
            albumEntity.Songs = item.Songs;
            albumEntity.Title = item.Title;
            albumEntity.Year = item.Year;

            this.dbContext.SaveChanges();

            return albumEntity;
        }

        public void Delete(int id)
        {
            Album album = this.entitySet.Find(id);
            if (album != null)
            {
                this.entitySet.Remove(album);
                this.dbContext.SaveChanges();
            }
        }
    }
}
