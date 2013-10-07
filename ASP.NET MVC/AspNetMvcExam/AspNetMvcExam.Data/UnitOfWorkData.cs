using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AspNetMvcExam.Models;

namespace AspNetMvcExam.Data
{
    public class UnitOfWorkData : IUnitOfWorkData
    {
        private readonly DbContext dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UnitOfWorkData()
            : this(new ApplicationDbContext())
        {
        }

        public UnitOfWorkData(DbContext context)
        {
            this.dbContext = context;
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

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }


        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                return this.GetRepository<Ticket>();
            }
        }
    }
}
