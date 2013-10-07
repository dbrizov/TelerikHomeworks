using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using Twitter.Data.Migrations;
using Twitter.Models;

namespace Twitter.Data
{
    public class TwitterDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Tweet> Tweets { get; set; }
        public IDbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
