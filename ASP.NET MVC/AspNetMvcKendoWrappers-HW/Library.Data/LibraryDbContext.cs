using Library.Data.Migrations;
using Library.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDbContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
