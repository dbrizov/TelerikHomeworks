using System;
using System.Linq;
using Twitter.Models;

namespace Twitter.Repositories
{
    public interface IUnitOfWorkData : IDisposable
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
