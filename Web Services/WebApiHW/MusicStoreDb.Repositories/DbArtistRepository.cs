using System;
using System.Data.Entity;
using System.Linq;
using MusicStoreDb.DataLayer;

namespace MusicStoreDb.Repositories
{
    public class DbArtistRepository : IRepository<Artist>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Artist> entitySet;

        public DbArtistRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Artist>();
        }

        public Artist Add(Artist item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Artist GetById(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Artist> GetAll()
        {
            return this.entitySet;
        }

        public Artist Update(int id, Artist item)
        {
            Artist artistEntity = this.entitySet.Find(id);
            artistEntity.Albums = item.Albums;
            artistEntity.Country = item.Country;
            artistEntity.DateOfBirth = item.DateOfBirth;
            artistEntity.Name = item.Name;
            artistEntity.Songs = item.Songs;

            this.dbContext.SaveChanges();

            return artistEntity;
        }

        public void Delete(int id)
        {
            Artist artistEntity = this.entitySet.Find(id);
            if (artistEntity != null)
            {
                this.entitySet.Remove(artistEntity);
                this.dbContext.SaveChanges();
            }
        }
    }
}
