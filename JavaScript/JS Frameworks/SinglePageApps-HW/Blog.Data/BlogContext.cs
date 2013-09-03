using System;
using System.Data.Entity;
using System.Linq;
using Blog.Models;
using Blog.Data.Migrations;

namespace Blog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("BlogDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
