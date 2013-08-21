using System;
using System.Data.Entity;
using System.Linq;
using ForumDb.Models;

namespace ForumDb.Repositories
{
    public class DbPostRepository : IRepository<Post>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Post> postEntities;

        public DbPostRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.postEntities = this.dbContext.Set<Post>();
        }

        public Post Add(Post item)
        {
            this.postEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Post GetById(int id)
        {
            return this.postEntities.Find(id);
        }

        public IQueryable<Post> GetAll()
        {
            return this.postEntities;
        }

        public Post Update(int id, Post item)
        {
            var post = this.postEntities.Find(id);

            if (post != null)
            {
                post.Comments = item.Comments;
                post.Content = item.Content;
                post.PostDate = item.PostDate;
                post.Thread = item.Thread;
                post.User = item.User;
                post.Votes = item.Votes;

                this.dbContext.SaveChanges();
            }

            return post;
        }

        public void Delete(int id)
        {
            var post = this.postEntities.Find(id);
            if (post != null)
            {
                this.postEntities.Remove(post);
                this.dbContext.SaveChanges();
            }
        }
    }
}
