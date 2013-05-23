using School;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudent_NameIsNull()
        {
            Student student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudent_NameIsEmptyString()
        {
            Student student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudent_UniqueNumberLessThan10000()
        {
            Student student = new Student("asd", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudent_UniqueNumberBiggerThan99999()
        {
            Student student = new Student("asd", 100000);
        }

        [TestMethod]
        public void TestEquals_AreEqual()
        {
            Student student1 = new Student("asd", 10000);
            Student student2 = new Student("asd", 10000);

            Assert.AreEqual(true, student1.Equals(student2));
        }

        [TestMethod]
        public void TestEquals_AreNotEqual1()
        {
            Student student1 = new Student("asd", 15000);
            Student student2 = new Student("asd", 10000);

            Assert.AreEqual(false, student1.Equals(student2), "They have only different unique numbers");
        }

        [TestMethod]
        public void TestEquals_AreNotEqual2()
        {
            Student student1 = new Student("qwe", 10000);
            Student student2 = new Student("asd", 10000);

            Assert.AreEqual(false, student1.Equals(student2), "They have only different names");
        }

        [TestMethod]
        public void TestEquals_ArgumentIsNotStudent()
        {
            Student student1 = new Student("asd", 10000);
            object someObj = 5;

            Assert.AreEqual(false, student1.Equals(someObj));
        }

        [TestMethod]
        public void TestGetHashCode_AreNotEqual()
        {
            Student student1 = new Student("asd", 10000);
            Student student2 = new Student("asd", 15000);

            Assert.AreNotEqual(student1.GetHashCode(), student2.GetHashCode());
        }

        [TestMethod]
        public void TestGetHashCode_AreEqual()
        {
            Student student1 = new Student("asd", 10000);
            Student student2 = new Student("asd", 10000);

            Assert.AreEqual(student1.GetHashCode(), student2.GetHashCode());
        }
    }
}
