using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EbayApplication.Models;
using System.Collections.Generic;
using EbayApplication.Repositories;
using Moq;
using EbayApplication.Web.Areas.Admin.Controllers;
using System.Web.Mvc;
using EbayApplication.Web.Models.ProductModels;
using System.Linq;
namespace EbayApplication.Tests
{
    [TestClass]
    public class AdminProductsControllerTests
    {
        [TestMethod]
        public void IndexMethodShouldReturnAllProducts()
        {
            var list = new List<Product>();
            list.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now,
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs" }
            });
            list.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now,
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs" }
            });

            var bugsRepoMock = new Mock<IRepository<Product>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Products).Returns(bugsRepoMock.Object);

            var controller = new AdminProductsController(uofMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ProductViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void IndexMethodShouldReturnProductsInTheSameOrder()
        {
            var list = new List<Product>();
            list.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now,
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs" }
            });
            list.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now,
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs" }
            });

            var bugsRepoMock = new Mock<IRepository<Product>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Products).Returns(bugsRepoMock.Object);

            var controller = new AdminProductsController(uofMock.Object);
            var viewResult = controller.Index() as ViewResult;           
            var model = viewResult.Model as IEnumerable<ProductViewModel>;

            Assert.AreEqual(list[0].Id, model.First().Id);
            Assert.AreEqual(list[1].Id, model.ElementAt(1).Id);
          
        }
    }
}
