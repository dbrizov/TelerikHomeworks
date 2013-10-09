using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EbayApplication.Repositories;
using EbayApplication.Models;
using Moq;
using System.Collections.Generic;
using EbayApplication.Web.Controllers;
using System.Web.Mvc;
using EbayApplication.Web.Models.UserModels;

namespace EbayApplication.Tests
{
    [TestClass]
    public class UsersControllerTests
    {


        [TestMethod]
        public void IndexShouldReturnTheProperNumberOfUsers()
        {
            Guid guid = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e85");
            Guid guid1 = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e81");
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho",
                Id = guid.ToString(),
                FirstName = "Ivan",
                LastName = "jorkov"
            };

            ApplicationUser user1 = new ApplicationUser()
            {
                UserName = "Pesho11111",
                Id = guid1.ToString(),
                FirstName = "Ivan",
                LastName = "jorkov"
            };
            List<ApplicationUser> users = new List<ApplicationUser>();
            users.Add(user);
            users.Add(user1);
            var usersRepoMock = new Mock<IRepository<ApplicationUser>>();

            usersRepoMock.Setup(x => x.All()).Returns(users.AsQueryable());


            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Users).Returns(usersRepoMock.Object);

            var controller = new UserController(uofMock.Object);

            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");

            var model = viewResult.Model as IEnumerable<UserViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());            
        }

        
        [TestMethod]
        public void GetByIdShouldReturnTheSameUser()
        {
            Guid guid = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e85");
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho",
                Id = guid.ToString(),
                FirstName = "Ivan",
                LastName = "jorkov"
            };

           // 
            var usersRepoMock = new Mock<IRepository<ApplicationUser>>();

            usersRepoMock.Setup(x => x.GetById(guid.ToString())).Returns(user);


            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Users).Returns(usersRepoMock.Object);
           
            var controller = new UserController(uofMock.Object);

            var viewResult = controller.Details(guid.ToString()) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");

            var model = viewResult.Model as UserViewModel;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(user.LastName, model.LastName);
            Assert.AreEqual(user.FirstName, model.FirstName);
            Assert.AreEqual(user.Id, model.Id);            
        }

        [TestMethod]
        public void EditShouldReturnTheSameUser()
        {
            Guid guid = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e85");
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho",
                Id = guid.ToString(),
                FirstName = "Ivan",
                LastName = "jorkov"
            };

            // 
            var usersRepoMock = new Mock<IRepository<ApplicationUser>>();

            usersRepoMock.Setup(x => x.GetById(guid.ToString())).Returns(user);


            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Users).Returns(usersRepoMock.Object);

            var controller = new UserController(uofMock.Object);

            var viewResult = controller.Edit(guid.ToString()) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");

            var model = viewResult.Model as UserViewModel;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(user.LastName, model.LastName);
            Assert.AreEqual(user.FirstName, model.FirstName);
            Assert.AreEqual(user.Id, model.Id);
        }

        [TestMethod]
        public void CreateShouldCreateProperUser()
        {
            Guid guid = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e85");
            UserViewModel user = new UserViewModel()
            {

                Id = guid.ToString(),
                FirstName = "Ivan",
                LastName = "jorkov"
            };

            var usersRepoMock = new Mock<IRepository<ApplicationUser>>();

            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Users).Returns(usersRepoMock.Object);

            var controller = new UserController(uofMock.Object);

            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(user);
            Assert.IsNotNull(result, "Create action returns null.");
            //Assert.AreEqual("Index", result.RouteValues); 
        }

        [TestMethod]
        public void DeleteShouldReturnTheSameUser()
        {
            Guid guid = new Guid("50d3ebaa-eea3-453f-8e8b-b835605b3e85");
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho",
                Id = guid.ToString(),
                FirstName = "Ivan",
                LastName = "jorkov"
            };

            // 
            var usersRepoMock = new Mock<IRepository<ApplicationUser>>();

            usersRepoMock.Setup(x => x.GetById(guid.ToString())).Returns(user);


            var uofMock = new Mock<IUnitOfWorkData>();
            uofMock.Setup(x => x.Users).Returns(usersRepoMock.Object);

            var controller = new UserController(uofMock.Object);

            var viewResult = controller.Delete(guid.ToString()) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");

            var model = viewResult.Model as UserViewModel;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(user.LastName, model.LastName);
            Assert.AreEqual(user.FirstName, model.FirstName);
            Assert.AreEqual(user.Id, model.Id);
        }
    }
}
