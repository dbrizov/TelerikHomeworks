using System;
using System.Collections.Generic;
using System.Linq;
using LaptopSystem.Data;
using System.Data.Entity;
using LaptopSystem.Models;

namespace LaptopSystem.Data
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

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IRepository<Laptop> Laptops
        {
            get
            {
                return this.GetRepository<Laptop>();
            }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }
    }
}
