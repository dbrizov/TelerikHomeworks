using System;
using System.Linq;
using Library.Models;

namespace Library.Repositories
{
    public interface IUnitOfWorkData : IDisposable
    {
        IRepository<Book> Books { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
