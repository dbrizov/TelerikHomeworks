namespace Library.Data.Migrations
{
    using Library.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Data.LibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Library.Data.LibraryDbContext context)
        {
            Random rand = new Random();

            int categoriesCount = 9;
            for (int i = 0; i < categoriesCount; i++)
            {
                var category = new Category()
                {
                    Name = "Category<br>#" + i
                };

                int booksCount = rand.Next(1, 6);
                for (int j = 0; j < booksCount; j++)
                {
                    var book = new Book()
                    {
                        Author = "Author<br>#" + i + " " + j,
                        Category = category,
                        Description = "Description<br>#" + i + " " + j,
                        Isbn = "Isbn<br>#" + i + " " + j,
                        Title = "Title<br>#" + i + " " + j,
                        WebSite = "WebSite<br>#" + i + " " + j
                    };

                    category.Books.Add(book);
                }

                context.Categories.AddOrUpdate(c => c.Name, category);
            }

            context.SaveChanges();
        }
    }
}
