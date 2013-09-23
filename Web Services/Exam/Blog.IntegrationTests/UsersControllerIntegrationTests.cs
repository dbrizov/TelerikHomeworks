using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.IntegrationTests.FakeRepositories;
using Blog.Models;
using System.Net;
using Blog.Services.Models;
using Newtonsoft.Json;

namespace Blog.IntegrationTests
{
    [TestClass]
    public class UsersControllerIntegrationTests
    {
        [TestMethod]
        public void Register_WhenUsernameContainsInvalidChars_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "javascript+C#",
                DisplayName = "JavaScript",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenUsernameIsLessThan6Chars_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "asd",
                DisplayName = "JavaScript",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenUsernameIsGreaterThan30Chars_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "asdasdasdashdahskdhkashdjkasdhkahsdjkashdjkahsdkhaksdasdasd",
                DisplayName = "JavaScript",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenDisplayNameisLessThan6Chars_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "asdasdasdasd",
                DisplayName = "asd",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenDisplayNameIsGreaterThan30Chars_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "golqmotopile",
                DisplayName = "asgbfuaysdgfugsdfgyudgdyfdgyugyugyuasdgyuyugasyudgfusydgfuysdgf",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenDisplayNameContainsInvalidChars_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "golqmotopile",
                DisplayName = "asd+asd=ASD",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenUserIsValid_ShouldReturnStatusCode201_AndSessionKey()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "validUserName",
                DisplayName = "Valid Display Name",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            string stringContent = response.Content.ReadAsStringAsync().Result;
            UserLoggedModel loggedUser = JsonConvert.DeserializeObject<UserLoggedModel>(stringContent);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(2, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
            Assert.IsNotNull(loggedUser.SessionKey);
        }

        [TestMethod]
        public void Register_WhenAuthCodeIsShort_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "validUserName",
                DisplayName = "Valid Display Name",
                AuthCode = "asd"
            };

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(1, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenAuthCodeIsTooLong_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "validUserName",
                DisplayName = "Valid Display Name",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            fakeRepo.Add(user);

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(2, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenUsernameAlreadyExists_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "validUserName",
                DisplayName = "DisplayName",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            fakeRepo.Add(new User
                {
                    Username = "validUserName",
                    DisplayName = "OtherDisplayName",
                    AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                });

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(2, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Register_WhenDisplayNameAlreadyExists_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var user = new User()
            {
                Username = "someUsername",
                DisplayName = "DisplayName",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            fakeRepo.Add(new User
            {
                Username = "otherUsername",
                DisplayName = "DisplayName",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            });

            var response = server.CreatePostRequest("api/users/register", user);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(2, fakeRepo.Entities.Count); // I put one user in the repository so that the ids begin from 1 (the first user is dummy)
        }

        [TestMethod]
        public void Logout_WhenSessionKeyIsValid_ShouldLogoutFromDatabaseAndReturnStatusCode200()
        {
            var fakeRepo = new FakeUserRepository();
            var user = new User()
            {
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            fakeRepo.Add(user);

            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var response = server.CreatePutRequest("api/users/logout?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH", new { });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Logout_WhenSessionKeyIsNotValid_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeUserRepository();
            var user = new User()
            {
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            fakeRepo.Add(user);

            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var response = server.CreatePutRequest("api/users/logout?sessionKey=stupidKey", new { });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
