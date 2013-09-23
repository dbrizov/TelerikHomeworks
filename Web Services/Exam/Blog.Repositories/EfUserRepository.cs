using System;
using System.Linq;
using Blog.Models;
using System.Data.Entity;

namespace Blog.Repositories
{
    public class EfUserRepository : IRepository<User>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<User> userEntities;

        public EfUserRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.userEntities = this.dbContext.Set<User>();
        }

        public User Add(User item)
        {
            this.userEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public User GetById(int id)
        {
            var user = this.userEntities.Find(id);
            return user;
        }

        public IQueryable<User> GetAll()
        {
            return this.userEntities;
        }

        public User Update(int id, User item)
        {
            var user = this.userEntities.Find(id);

            if (user != null)
            {
                user.AuthCode = item.AuthCode;
                user.Comments = item.Comments;
                user.DisplayName = item.DisplayName;
                user.Posts = item.Posts;
                user.SessionKey = item.SessionKey;
                user.Username = item.Username;

                this.dbContext.SaveChanges();
            }

            return user;
        }

        public void Delete(int id)
        {
            var user = this.userEntities.Find(id);
            if (user != null)
            {
                this.userEntities.Remove(user);
                this.dbContext.SaveChanges();
            }
        }
    }
}
