using System;
using System.Data.Entity;
using System.Linq;
using ForumDb.Models;

namespace ForumDb.Repositories
{
    public class DbUserRepository : IRepository<User>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<User> userEntities;

        public DbUserRepository(DbContext dbContext)
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
                user.Nickname = item.Nickname;
                user.Posts = item.Posts;
                user.SessionKey = item.SessionKey;
                user.Threads = item.Threads;
                user.Username = item.Username;
                user.Votes = item.Votes;
                user.AuthCode = item.AuthCode;
                user.Comments = item.Comments;

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
