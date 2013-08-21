using System;
using System.Data.Entity;
using System.Linq;
using ForumDb.Models;

namespace ForumDb.Repositories
{
    public class DbThreadRepository : IRepository<Thread>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Thread> threadEntities;

        public DbThreadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.threadEntities = this.dbContext.Set<Thread>();
        }

        public Thread Add(Thread item)
        {
            this.threadEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Thread GetById(int id)
        {
            return this.threadEntities.Find(id);
        }

        public IQueryable<Thread> GetAll()
        {
            return this.threadEntities;
        }

        public Thread Update(int id, Thread item)
        {
            var entity = this.threadEntities.Find(id);

            if (entity != null)
            {
                entity.Categories = item.Categories;
                entity.Content = item.Content;
                entity.Creator = item.Creator;
                entity.DateCreated = item.DateCreated;
                entity.Posts = item.Posts;
                entity.Title = item.Title;

                this.dbContext.SaveChanges();
            }

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.threadEntities.Find(id);
            if (entity != null)
            {
                this.threadEntities.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }
    }
}
