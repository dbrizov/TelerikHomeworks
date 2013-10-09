using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EbayApplication.Models;
using Moq;
using EbayApplication.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using EbayApplication.Repositories;
using EbayApplication.Web.Controllers;
using System.Web.Mvc;
using EbayApplication.Web.Models.ProductModels;
namespace EbayApplication.Tests
{
    [TestClass]
    public class HomeControllerTest
    {    
        [TestMethod]
        public void IndexMethodShouldReturn1Product()
       {
            Product product = new Product()
            {
                  Id = Guid.NewGuid(), Title = "test", 
                Description = "1234567891011121212512255621dfsdfsd", Price = 10,
                StartingPrice = 5, DateAdded = DateTime.Now, ImageUrl = "test",
                Category = new Category { 
                    Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs"
                }                
            };

            Auction auction = new Auction()
            {
                Id = Guid.NewGuid(),
                DateStarted = DateTime.Now,
                Duration = 12,
                Type = AuctionType.Auction,
                Product = product,
                DeliveryDuration = 123,
                CurrentPrice = 123,                
            };

            var list = new List<Auction>();
            list.Add(auction);

            var bugsRepoMock = new Mock<IRepository<Auction>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Auctions).Returns(bugsRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IList<ProductViewModel>;

            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(1, model.Count());
            Assert.AreEqual(product.Description, model[0].Description);
       }


        [TestMethod]
        public void IndexMethodShouldReturnSortedProductInDescending()
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now,
                ImageUrl = "test",
                Category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "dsfdsfsfdsfsfs"
                }
            };

            Auction auction = new Auction()
            {
                Id = Guid.NewGuid(),
                DateStarted = DateTime.Now,
                Duration = 12,
                Type = AuctionType.Auction,
                Product = product,
                DeliveryDuration = 123,
                CurrentPrice = 123,
            };

            Product product1 = new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd1",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now.AddMinutes(3),
                ImageUrl = "test",
                Category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "dsfdsfsfdsfsfs"
                }
            };

            Auction auction1 = new Auction()
            {
                Id = Guid.NewGuid(),
                DateStarted = DateTime.Now,
                Duration = 12,
                Type = AuctionType.Auction,
                Product = product1,
                DeliveryDuration = 123,
                CurrentPrice = 123,
            };

            var list = new List<Auction>();
            list.Add(auction);
            list.Add(auction1);

            var bugsRepoMock = new Mock<IRepository<Auction>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Auctions).Returns(bugsRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IList<ProductViewModel>;

            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
            Assert.AreEqual(product1.Description, model[0].Description);
            Assert.AreEqual(product.Description , model[1].Description);
            Assert.IsTrue(model[0].DateAdded > model[1].DateAdded);
        }

        [TestMethod]
        public void IndexMethodAdding26ProductsShouldReturn24()
        {
            var list = new List<Auction>();

            for (int i = 0; i < 26; i++)
            {
                Product product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = "test",
                    Description = "1234567891011121212512255621dfsdfsd",
                    Price = 10,
                    StartingPrice = 5,
                    DateAdded = DateTime.Now,
                    ImageUrl = "test",
                    Category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = "dsfdsfsfdsfsfs"
                    }
                };

                Auction auction = new Auction()
                {
                    Id = Guid.NewGuid(),
                    DateStarted = DateTime.Now,
                    Duration = 12,
                    Type = AuctionType.Auction,
                    Product = product,
                    DeliveryDuration = 123,
                    CurrentPrice = 123,
                };
                list.Add(auction);                
            }

            var bugsRepoMock = new Mock<IRepository<Auction>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Auctions).Returns(bugsRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IList<ProductViewModel>;

            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(24, model.Count());           
        }
    }
}
