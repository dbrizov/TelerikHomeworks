using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.DataLayer;
using StudentsDb.Services.Tests.FakeRepositories;

namespace StudentsDb.Services.IntegrationTests
{
    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var fakeRepo = new FakeStudentRepository();

            var student = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            fakeRepo.Add(student);

            var server = new InMemoryHttpServer<Student>("http://localhost/", fakeRepo);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetById_ShouldGetStudent()
        {
            var fakeRepo = new FakeStudentRepository();

            var student1 = new Student()
            {
                StudentId = 1,
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            var student2 = new Student()
            {
                StudentId = 2,
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            fakeRepo.Add(student2);
            fakeRepo.Add(student1);

            var server = new InMemoryHttpServer<Student>("http://localhost/", fakeRepo);

            var response = server.CreateGetRequest("api/students/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostStudent_WhenNameIsNull_ShouldReturnStatusCode400()
        {
            var fakeRepo = new FakeStudentRepository();

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", fakeRepo);

            var response = server.CreatePostRequest("api/students",
                new Student()
                {
                    FirstName = null,
                    LastName = "Markov",
                    School = new School(),
                    Grade = 5
                });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostStudent_WhenValidStudent_ShouldReturnStatusCode201()
        {
            var fakeRepo = new FakeStudentRepository();

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", fakeRepo);

            var response = server.CreatePostRequest("api/students",
                new Student()
                {
                    FirstName = "Minko",
                    LastName = "Markov",
                    School = new School(),
                    Grade = 5
                });

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
