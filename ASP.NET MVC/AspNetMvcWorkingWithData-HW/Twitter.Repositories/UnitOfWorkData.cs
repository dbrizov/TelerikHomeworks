using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Repositories
{
    public class UnitOfWorkData : IUnitOfWorkData
    {
        private readonly TwitterDbContext dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UnitOfWorkData()
            : this(new TwitterDbContext())
        {
        }

        public UnitOfWorkData(TwitterDbContext context)
        {
            this.dbContext = context;
        }

        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
