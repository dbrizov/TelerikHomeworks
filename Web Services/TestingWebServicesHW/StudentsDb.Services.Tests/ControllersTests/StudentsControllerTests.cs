using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.DataLayer;
using StudentsDb.Services.Controllers;
using StudentsDb.Services.Tests.FakeRepositories;

namespace StudentsDb.Services.Tests.ControllersTests
{
    [TestClass]
    public class StudentsControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void PostStudent_WhenStudentIsNull_StudentShouldnotBeAdded()
        {
            var fakeRepo = new FakeStudentRepository();
            var controller = new StudentsController(fakeRepo);

            Student studentEnitity = null;

            SetupController(controller);
            controller.PostStudent(studentEnitity);

            Assert.AreEqual(0, fakeRepo.Entities.Count);
        }

        [TestMethod]
        public void PostStudent_WhenStudentFirstNameIsNull_StudentShouldnotBeAdded()
        {
            var fakeRepo = new FakeStudentRepository();
            var controller = new StudentsController(fakeRepo);

            Student studentEnitity = new Student()
            {
                FirstName = null
            };

            SetupController(controller);
            controller.PostStudent(studentEnitity);

            Assert.AreEqual(0, fakeRepo.Entities.Count);
        }

        [TestMethod]
        public void PostStudent_WhenStudentSchoolIsNull_StudentShouldNotBeAdded()
        {
            var fakeRepo = new FakeStudentRepository();
            var controller = new StudentsController(fakeRepo);

            Student studentEnitity = new Student()
            {
                School = null
            };

            SetupController(controller);
            controller.PostStudent(studentEnitity);

            Assert.AreEqual(0, fakeRepo.Entities.Count);
        }

        [TestMethod]
        public void PostStudent_WhenStudentLastNameIsNull_StudentShouldNotBeAdded()
        {
            var fakeRepo = new FakeStudentRepository();
            var controller = new StudentsController(fakeRepo);

            Student studentEnitity = new Student()
            {
                LastName = null
            };

            SetupController(controller);
            controller.PostStudent(studentEnitity);

            Assert.AreEqual(0, fakeRepo.Entities.Count);
        }

        [TestMethod]
        public void PostStudent_WhenStudentIsValid_StudentShouldBeAdded()
        {
            var fakeRepo = new FakeStudentRepository();
            var controller = new StudentsController(fakeRepo);

            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            SetupController(controller);
            controller.PostStudent(studentEnitity);

            Assert.AreEqual(1, fakeRepo.Entities.Count);
        }

        [TestMethod]
        public void GetById_ShouldGetStudent()
        {
            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            var fakeRepo = new FakeStudentRepository();
            fakeRepo.Entities.Add(studentEnitity);
            fakeRepo.Entities.Add(studentEnitity);
            var controller = new StudentsController(fakeRepo);

            SetupController(controller);
            var student = controller.Get(1);
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void GetAll_ShouldGetStudents()
        {
            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            var fakeRepo = new FakeStudentRepository();
            fakeRepo.Entities.Add(studentEnitity);
            fakeRepo.Entities.Add(studentEnitity);
            var controller = new StudentsController(fakeRepo);

            SetupController(controller);
            var students = controller.GetAll();

            Assert.IsNotNull(students);
            Assert.AreEqual(2, students.Count());
        }

        [TestMethod]
        public void Find_ShouldReturnOneStudent()
        {
            Mark markEntity = new Mark()
            {
                Subject = "Math",
                Value = 5
            };

            var marks = new List<Mark>();
            marks.Add(markEntity);

            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5,
                Marks = marks
            };

            var fakeRepo = new FakeStudentRepository();
            fakeRepo.Add(studentEnitity);
            var controller = new StudentsController(fakeRepo);
            SetupController(controller);
            var students = controller.Find("Math", 5);

            Assert.IsNotNull(students);
            Assert.AreEqual(1, students.Count());
        }

        [TestMethod]
        public void Update_ShouldUpdateStudent()
        {
            Student studentEnitity = new Student()
            {
                StudentId = 1,
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            var fakeRepo = new FakeStudentRepository();
            fakeRepo.Add(studentEnitity);
            fakeRepo.Add(studentEnitity);
            var controller = new StudentsController(fakeRepo);

            studentEnitity.FirstName = "Kiro";

            SetupController(controller);
            controller.PutStudent(studentEnitity.StudentId, studentEnitity);

            var student = controller.Get(studentEnitity.StudentId);

            Assert.IsNotNull(student);
            Assert.AreEqual("Kiro", student.FirstName);
        }

        [TestMethod]
        public void DeleteStudent_ShouldDeleteStudent()
        {
            Student studentEnitity = new Student()
            {
                StudentId = 1,
                FirstName = "Minko",
                LastName = "Markov",
                School = new School(),
                Grade = 5
            };

            var fakeRepo = new FakeStudentRepository();
            fakeRepo.Add(studentEnitity);
            fakeRepo.Add(studentEnitity);
            var controller = new StudentsController(fakeRepo);

            studentEnitity.FirstName = "Kiro";

            SetupController(controller);
            controller.PutStudent(studentEnitity.StudentId, studentEnitity);

            controller.DeleteStudent(studentEnitity.StudentId);

            Assert.AreEqual(1, fakeRepo.Entities.Count());
        }
    }
}
