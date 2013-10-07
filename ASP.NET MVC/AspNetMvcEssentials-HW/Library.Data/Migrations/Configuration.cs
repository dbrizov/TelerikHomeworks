namespace Library.Data.Migrations
{
    using Library.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Data.LibraryContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Library.Data.LibraryContext context)
        {
            int categoriesCount = 5;
            for (int i = 0; i < categoriesCount; i++)
            {
                Category category = new Category()
                {
                    Name = "Cagegory " + i
                };

                int booksCount = 5;
                for (int j = 0; j < booksCount; j++)
                {
                    Book book = new Book()
                    {
                        Author = "Author " + i + " " + j,
                        Category = category,
                        Content = "Content " + i + " " + j,
                        Title = "Title " + i + " " + j
                    };

                    context.Books.AddOrUpdate(b => b.Title, book);
                }
            }

            context.SaveChanges();
        }
    }
}
