using System;
using System.Data.Entity;
using System.Linq;
using ForumDb.Models;

namespace ForumDb.Repositories
{
    public class DbVoteRepository : IRepository<Vote>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Vote> voteEntities;

        public DbVoteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.voteEntities = this.dbContext.Set<Vote>();
        }

        public Vote Add(Vote item)
        {
            this.voteEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Vote GetById(int id)
        {
            return this.voteEntities.Find(id);
        }

        public IQueryable<Vote> GetAll()
        {
            return this.voteEntities;
        }

        public Vote Update(int id, Vote item)
        {
            var vote = this.voteEntities.Find(id);
            if (vote != null)
            {
                vote.Post = item.Post;
                vote.User = item.User;
                vote.Value = item.Value;

                this.dbContext.SaveChanges();
            }

            return vote;
        }

        public void Delete(int id)
        {
            var vote = this.voteEntities.Find(id);
            if (vote != null)
            {
                this.voteEntities.Remove(vote);
                this.dbContext.SaveChanges();
            }
        }
    }
}
