using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Twitter.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected readonly IDbSet<T> entities;

        public EfRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext", "An instance of DbContext is required to use this repository");
            }

            this.dbContext = dbContext;
            this.entities = this.dbContext.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.entities.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.entities.Find(id);
        }

        public virtual void Add(T entity)
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
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entities.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.dbContext.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.entities.Attach(entity);
                this.entities.Remove(entity);
            }
        }

        public virtual void Delete(object id)
        {
            var entity = this.entities.Find(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.dbContext.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}
