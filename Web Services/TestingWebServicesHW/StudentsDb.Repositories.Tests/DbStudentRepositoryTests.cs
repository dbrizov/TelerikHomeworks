using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.DataLayer;

namespace StudentsDb.Repositories.Tests
{
    [TestClass]
    public class DbStudentRepositoryTests
    {
        public DbContext DbContext { get; set; }

        public IRepository<Student> StudentRepository { get; set; }

        private static TransactionScope tranScope;

        public DbStudentRepositoryTests()
        {
            this.DbContext = new StudentsDbEntities();
            this.StudentRepository = new DbStudentRepository(this.DbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void Add_WhenStudentIsValid_ShoulAddStudentToDatabase()
        {
            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                SchoolId = 1,
                Grade = 5
            };

            var createdStudent = this.StudentRepository.Add(studentEnitity);
            var foundStudent = this.DbContext.Set<Student>().Find(createdStudent.StudentId);

            Assert.IsNotNull(foundStudent);
            Assert.AreEqual(studentEnitity.FirstName, foundStudent.FirstName);
            Assert.AreEqual(studentEnitity.LastName, foundStudent.LastName);
            Assert.AreEqual(studentEnitity.Grade, foundStudent.Grade);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_WhenStudentIsNull_ShouldThrowArgumentNullException()
        {
            Student studentEnitity = null;

            this.StudentRepository.Add(studentEnitity);
        }

        [TestMethod]
        public void Add_WhenStudentIsValid_ShouldReturnNonZeroId()
        {
            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                SchoolId = 1,
                Grade = 5
            };

            var createdStudent = this.StudentRepository.Add(studentEnitity);

            Assert.IsTrue(createdStudent.StudentId != 0);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllStudents()
        {
            var entities = this.StudentRepository.GetAll().ToList();

            int actual = this.DbContext.Set<Student>().Count();

            Assert.AreEqual(actual, entities.Count());
        }

        [TestMethod]
        public void GetById_WhenIdIsValid_ShouldReturnCorrectStudent()
        {
            var student = this.StudentRepository.GetById(1);

            Assert.AreEqual("Pesho", student.FirstName);
            Assert.AreEqual("Peshov", student.LastName);
            Assert.AreEqual(5.00, student.Grade);
            Assert.AreEqual(1, student.StudentId);
            Assert.AreEqual(1, student.SchoolId);
        }

        [TestMethod]
        public void GetById_WhenIdIsInvalid_ShouldReturnCorrectStudent()
        {
            var student = this.StudentRepository.GetById(-5);

            Assert.IsNull(student);
        }

        [TestMethod]
        public void Find_WhenExpressionIsTrue_ShouldReturnNonEmptyList()
        {
            var students = this.StudentRepository.Find(
                s => s.Marks.Any(m => m.Subject == "History" && m.Value == 6)).ToList();

            Assert.IsNotNull(students);
            Assert.IsTrue(students.Count > 0);
        }

        [TestMethod]
        public void Update_WhenIdIsValid_ShouldUpdateTheStudent()
        {
            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                SchoolId = 1,
                Grade = 2
            };

            this.StudentRepository.Update(1, studentEnitity);

            var updatedStudent = this.DbContext.Set<Student>().Find(1);

            Assert.AreEqual(1, updatedStudent.StudentId);
            Assert.AreEqual("Minko", updatedStudent.FirstName);
            Assert.AreEqual("Markov", updatedStudent.LastName);
            Assert.AreEqual(2, updatedStudent.Grade);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Update_WhenIdIsNotValid_ShouldThrowNullReferenceException()
        {
            Student studentEnitity = new Student()
            {
                FirstName = "Minko",
                LastName = "Markov",
                SchoolId = 1,
                Grade = 2
            };

            this.StudentRepository.Update(-1, studentEnitity);
        }

        [TestMethod]
        public void Delete_WhenIdIsValid_ShouldDepeteStudent()
        {
            var markEntities = this.DbContext.Set<Mark>();
            var mark = markEntities.Find(1);
            markEntities.Remove(mark);
            this.DbContext.SaveChanges();

            this.StudentRepository.Delete(1);

            var student = this.DbContext.Set<Student>().Find(1);

            Assert.IsNull(student);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Delete_WhenIdIsNotValid_ShouldThrowNullReferenceException()
        {
            this.StudentRepository.Delete(-1);
        }
    }
}
