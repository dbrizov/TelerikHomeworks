using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Models;
using System.Data.Entity;

namespace Library.Repositories
{
    public class UnitOfWorkData : IUnitOfWorkData
    {
        private readonly DbContext dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UnitOfWorkData()
            : this(new LibraryDbContext())
        {
        }

        public UnitOfWorkData(DbContext context)
        {
            this.dbContext = context;
        }

        public IRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
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
