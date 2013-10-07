using System;
using System.Data.Entity;
using System.Linq;
using Library.Models;
using Library.Data.Migrations;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("LibraryDb")
        {
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
