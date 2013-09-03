using System.Data.Entity;
using Blog.Models;
using System;
using System.Linq;

namespace Blog.Repositories
{
    public class EfCommentRepository :  IRepository<Comment>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Comment> commentEntities;

        public EfCommentRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.commentEntities = this.dbContext.Set<Comment>();
        }

        public Comment Add(Comment item)
        {
            this.commentEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Comment GetById(int id)
        {
            return this.commentEntities.Find(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return this.commentEntities;
        }

        public Comment Update(int id, Comment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
