using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EbayApplication.Models;
using System.Collections.Generic;
using EbayApplication.Repositories;
using Moq;
using EbayApplication.Web.Controllers;
using EbayApplication.Web.Models.ProductModels;

namespace EbayApplication.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void IndexMethod_ShouldReturnProperNumberOfProducts()
        {
            var list = new List<Product>();
            list.Add(new Product() { Id = Guid.NewGuid(), Title = "test", 
                Description = "1234567891011121212512255621dfsdfsd", Price = 10,
                StartingPrice = 5, DateAdded = DateTime.Now,
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs"} });
            list.Add(new Product() { Id = Guid.NewGuid(), Title = "test",
                Description = "1234567891011121212512255621dfsdfsd", Price = 10,
                StartingPrice = 5, DateAdded = DateTime.Now, 
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs" } });

            var bugsRepoMock = new Mock<IRepository<Product>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Products).Returns(bugsRepoMock.Object);

            var controller = new ProductsController(uofMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ProductViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void EditMethod_ShouldReturnProperProduct()
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "1234567891011121212512255621dfsdfsd",
                Price = 10,
                StartingPrice = 5,
                DateAdded = DateTime.Now,
                Category = new Category { Id = Guid.NewGuid(), Name = "dsfdsfsfdsfsfs" }
            };

            Guid guid1 = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e85");
            var productsRepoMock = new Mock<IRepository<Product>>();
            var categoriesRepoMock = new Mock<IRepository<Category>>();
            productsRepoMock.Setup(x => x.GetById(guid1)).Returns(product);

            List<Category> list = new List<Category>()
            {
                new Category(){Name = "category1", Id = Guid.NewGuid(), },
                new Category(){Name = "category2", Id = Guid.NewGuid() }
            };

            categoriesRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Products).Returns(productsRepoMock.Object);
            uofMock.Setup(x => x.Categories).Returns(categoriesRepoMock.Object);
            var controller = new ProductsController(uofMock.Object);

            var viewResult = controller.Edit(guid1) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");

             var model = viewResult.Model as Product;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(10, model.Price);
            Assert.AreEqual(5, model.StartingPrice);
            Assert.AreEqual("test", model.Title);

            Assert.AreSame(product, model);
           
        }
    }
    
}
