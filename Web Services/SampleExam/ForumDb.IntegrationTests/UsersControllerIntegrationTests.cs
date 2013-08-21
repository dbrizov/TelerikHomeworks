using System;
using System.Net;
using ForumDb.IntegrationTests.FakeRepositories;
using ForumDb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForumDb.IntegrationTests
{
    [TestClass]
    public class UsersControllerIntegrationTests
    {
        [TestMethod]
        public void Login_WhenUserIsValid_ShouldLoginInDatabase()
        {
            var fakeRepo = new FakeUserRepository();
            var user = new User()
            {
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            fakeRepo.Add(user);

            var server = new InMemoryHttpServer<User>("http://localhost/", fakeRepo);

            var response = server.CreatePostRequest("api/users/login", user);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Logout_WhenSessionKeyIsValid_ShouldLogoutFromDatabase()
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

            var sessionKey = new { sessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH" };
            var response = server.CreatePutRequest("api/users/logout", sessionKey);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
