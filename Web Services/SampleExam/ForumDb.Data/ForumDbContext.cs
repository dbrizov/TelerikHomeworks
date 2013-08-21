using System;
using System.Data.Entity;
using System.Linq;
using ForumDb.Data.Migrations;
using ForumDb.Models;

namespace ForumDb.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
            : base("ForumDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
