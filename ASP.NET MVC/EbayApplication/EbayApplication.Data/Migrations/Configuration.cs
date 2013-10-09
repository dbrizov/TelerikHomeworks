namespace EbayApplication.Data.Migrations
{
    using System.Linq;
    using EbayApplication.Models;
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<EbayEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EbayApplication.Data.EbayEntities context)
        {
            if (context.Categories.Count() > 0)
            {
                return;
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = "test",
                LastName = "user",
                UserName = "testuser5"
            };

            user.CreditCard = new CreditCard()
            {
                CardNumber = "1234567890123",
                Owner = user,
                Funds = 1000,
                Id = Guid.NewGuid()
            };

            user.ShoppingCart = new ShoppingCart()
            {
                Id = Guid.NewGuid(),
                Owner = user
            };

            int categoriesCount = 10;
            for (int i = 0; i < categoriesCount; i++)
            {
                var category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "CategoryName#" + i
                };

                int productsCount = 25;
                for (int j = 0; j < productsCount; j++)
                {
                    var product = new Product()
                    {
                        Id = Guid.NewGuid(),
                        Category = category,
                        Condition = Condition.BrandNew,
                        DateAdded = DateTime.Now,
                        Description = "ProductDescription#ProductDescription#" + i + " " + j,
                        Price = (decimal)(i + 10),
                        StartingPrice = 0.01m,
                        State = ProductState.ForSelling,
                        Title = "ProductTitle#" + i + " " + j,
                        ImageUrl = "default-product-image.jpg",
                        Owner = user

                    };

                    category.Products.Add(product);

                    var date = new DateTime(2013, i + 1, j + 1);
                    var auction = new Auction()
                    {
                        Id = Guid.NewGuid(),
                        DateStarted = date,
                        Duration = (i + j) / (i + 1) + 1,
                        CurrentPrice = 1m,
                        //StartingPrice = 1m,
                        //MaximalPrice = 5m,
                        DeliveryDuration = ((i + j) / (i + 1) * (j + 2)) == 0 ? 5 : (i + j) / (i + 1) * (j + 2),
                        Product = product,
                        Type = ((i + j) % 2 == 0 ? AuctionType.Auction : AuctionType.Normal),
                        HasMaxPrice = (i + j) % 2 == 0 ? true : false
                    };

                    context.Auctions.AddOrUpdate(a => a.DateStarted, auction);
                }

                context.Categories.AddOrUpdate(c => c.Name, category);
            }

            context.SaveChanges();
        }
    }
}
