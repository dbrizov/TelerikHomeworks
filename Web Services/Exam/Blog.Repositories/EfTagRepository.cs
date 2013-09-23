using System.Data.Entity;
using Blog.Models;
using System;
using System.Linq;

namespace Blog.Repositories
{
    public class EfTagRepository : IRepository<Tag>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Tag> tagEntities;

        public EfTagRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.tagEntities = this.dbContext.Set<Tag>();
        }

        public Tag Add(Tag item)
        {
            this.tagEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Tag GetById(int id)
        {
            return this.tagEntities.Find(id);
        }

        public IQueryable<Tag> GetAll()
        {
            return this.tagEntities;
        }

        public Tag Update(int id, Tag item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
