using System.Data.Entity;
using Blog.Models;
using System;
using System.Linq;

namespace Blog.Repositories
{
    public class EfPostRepository : IRepository<Post>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Post> postEntities;

        public EfPostRepository(DbContext dbContext)
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
                post.PostDate = item.PostDate;
                post.Tags = item.Tags;
                post.Text = item.Text;
                post.Title = item.Title;
                post.User = item.User;

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
