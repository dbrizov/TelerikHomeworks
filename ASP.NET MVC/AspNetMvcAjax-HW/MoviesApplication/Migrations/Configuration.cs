namespace MoviesApplication.Migrations
{
    using MoviesApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesApplication.Models.ApplicationDbContext context)
        {
            int moviesCount = 10;
            for (int i = 0; i < moviesCount; i++)
            {
                Movie movie = new Movie()
                {
                    Director = "Director " + i,
                    LeadingFemaleRole = "Female actor " + i,
                    LeadingMaleRole = "Male actor " + i,
                    Studio = "Studio " + i,
                    StudioAddress = "Studion address " + i,
                    Title = "Title " + i,
                    Year = 1990 + i
                };

                context.Movies.AddOrUpdate(m => m.Title, movie);
            }
        }
    }
}
