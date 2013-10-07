using System;
using System.Linq;
using AspNetMvcExam.Models;

namespace AspNetMvcExam.Data
{
    public interface IUnitOfWorkData : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Category> Categories { get; }

        IRepository<Ticket> Tickets { get; }

        int SaveChanges();
    }
}
