using System;
using System.Linq;
using EbayApplication.Models;

namespace EbayApplication.Repositories
{
    public interface IUnitOfWorkData : IDisposable
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<Delivery> Deliveries { get; }

        IRepository<Auction> Auctions { get; }

        IRepository<ShoppingCart> ShoppingCarts { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<CreditCard> CreditCards { get; }

        IRepository<Transaction> Transactions { get; }

        int SaveChanges();
    }
}
