using System;
using System.Linq;
using LaptopSystem.Models;

namespace LaptopSystem.Data
{
    public interface IUnitOfWorkData : IDisposable
    {
        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Laptop> Laptops { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
