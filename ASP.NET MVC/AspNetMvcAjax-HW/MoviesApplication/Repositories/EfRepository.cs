using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MoviesApplication.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly IDbSet<T> entities;

        public EfRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entities.Add(entity);
            }
            else
            {
                entry.State = EntityState.Added;
            }

            this.dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return this.entities;
        }

        public T GetById(int id)
        {
            var entity = this.entities.Find(id);
            return entity;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entities.Attach(entity);
            }

            entry.State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.entities.Find(id);

            if (entity != null)
            {
                this.entities.Remove(entity);
            }

            this.dbContext.SaveChanges();
        }
    }
}