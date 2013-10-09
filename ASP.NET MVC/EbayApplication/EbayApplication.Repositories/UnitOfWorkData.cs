using System;
using System.Collections.Generic;
using System.Linq;
using EbayApplication.Data;
using EbayApplication.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace EbayApplication.Repositories
{
    public class UnitOfWorkData : IUnitOfWorkData
    {
        private readonly EbayEntities dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UnitOfWorkData()
            : this(new EbayEntities())
        {
        }

        public UnitOfWorkData(EbayEntities context)
        {
            this.dbContext = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Delivery> Deliveries
        {
            get
            {
                return this.GetRepository<Delivery>();
            }
        }

        public IRepository<Auction> Auctions
        {
            get
            {
                return this.GetRepository<Auction>();
            }
        }

        public IRepository<ShoppingCart> ShoppingCarts
        {
            get
            {
                return this.GetRepository<ShoppingCart>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<CreditCard> CreditCards
        {
            get
            {
                return this.GetRepository<CreditCard>();
            }
        }

        public IRepository<Transaction> Transactions
        {
            get { return this.GetRepository<Transaction>(); }
        }

        public int SaveChanges()
        {
            try
            {
                return this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                return this.dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);

                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }


        
    }
}
