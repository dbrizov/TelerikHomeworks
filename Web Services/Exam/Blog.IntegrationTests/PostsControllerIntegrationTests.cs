using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.IntegrationTests.FakeRepositories;
using Blog.Models;
using System.Net;

namespace Blog.IntegrationTests
{
    [TestClass]
    public class PostsControllerIntegrationTests
    {
        [TestMethod]
        public void Create_WhenPostIsValid_ShouldReturnStatusCode201()
        {
            var fakeUserRepo = new FakeUserRepository();
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            fakeUserRepo.Add(user);

            var fakePostRepo = new FakePostRepository();

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var newPost = new
            {
                title = "nov post",
                text = "malko test",
                tags = new string[] { "asd", "qwe" }
            };


            var response = server.CreatePostRequest("api/posts?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH", newPost);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Create_WhenPostTitleIsNull_ShouldReturnStatusCode400()
        {
            var fakeUserRepo = new FakeUserRepository();
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            fakeUserRepo.Add(user);

            var fakePostRepo = new FakePostRepository();

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var newPost = new
            {
                text = "malko test",
                tags = new string[] { "asd", "qwe" }
            };


            var response = server.CreatePostRequest("api/posts?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH", newPost);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Create_WhenPostTextIsNull_ShouldReturnStatusCode400()
        {
            var fakeUserRepo = new FakeUserRepository();
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            fakeUserRepo.Add(user);

            var fakePostRepo = new FakePostRepository();

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var newPost = new
            {
                title = "some title",
                tags = new string[] { "asd", "qwe" }
            };


            var response = server.CreatePostRequest("api/posts?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH", newPost);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Create_WhenSessionKeyIsInvlid_ShouldReturnStatusCode400()
        {
            var fakeUserRepo = new FakeUserRepository();
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            fakeUserRepo.Add(user);

            var fakePostRepo = new FakePostRepository();

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var newPost = new
            {
                title = "nov post",
                text = "malko test",
                tags = new string[] { "asd", "qwe" }
            };


            var response = server.CreatePostRequest("api/posts?sessionKey=invalidSessionKey", newPost);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void GetByTags_WhenTagsAreCorrect_ShouldReturnStatusCode200()
        {
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            var fakeUserRepo = new FakeUserRepository();
            fakeUserRepo.Add(user);

            var post = new Post()
            {
                PostDate = DateTime.Now,
                Text = "Some text",
                Title = "SomeTitle",
                User = user
            };

            var fakePostRepo = new FakePostRepository();
            fakePostRepo.Add(post);

            var tags = new List<Tag>()
            {
                new Tag()
                {
                    Name = "c#",
                    Posts = new List<Post>() { post }
                },

                new Tag()
                {
                    Name = "web",
                    Posts = new List<Post>() { post }
                },
            };

            var fakeTagRepo = new FakeTagRepository();
            fakeTagRepo.Add(tags[0]);
            fakeTagRepo.Add(tags[1]);

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var response = server.CreateGetRequest("api/posts?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH&tags=c#,web");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void GetByTags_WhenTagsAreNotCorrect_ShouldReturnNoContent()
        {
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            var fakeUserRepo = new FakeUserRepository();
            fakeUserRepo.Add(user);

            var post = new Post()
            {
                PostDate = DateTime.Now,
                Text = "Some text",
                Title = "SomeTitle",
                User = user
            };

            var fakePostRepo = new FakePostRepository();
            fakePostRepo.Add(post);

            var tags = new List<Tag>()
            {
                new Tag()
                {
                    Name = "c#",
                    Posts = new List<Post>() { post }
                },

                new Tag()
                {
                    Name = "web",
                    Posts = new List<Post>() { post }
                },
            };

            var fakeTagRepo = new FakeTagRepository();
            fakeTagRepo.Add(tags[0]);
            fakeTagRepo.Add(tags[1]);

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var response = server.CreateGetRequest("api/posts?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH&tags=js");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void CommentPost_WhenSessionKeyIsNotCorrect_ShouldReturnStatusCode400()
        {
            var user = new User()
            {
                DisplayName = "JavaScript",
                Username = "golqmotopile",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            };

            var fakeUserRepo = new FakeUserRepository();
            fakeUserRepo.Add(user);

            var post = new Post()
            {
                PostDate = DateTime.Now,
                Text = "Some text",
                Title = "SomeTitle",
                User = user
            };

            var fakePostRepo = new FakePostRepository();
            fakePostRepo.Add(post);

            var server = new InMemoryHttpServer<Post>("http://localhost/", fakePostRepo);
            var response = server.CreateGetRequest("api/posts?sessionKey=1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH&tags");

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
