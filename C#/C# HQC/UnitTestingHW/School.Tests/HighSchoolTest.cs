using School;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class HighSchoolTest
    {
        [TestMethod]
        public void TestHighSchool_StudentEqualsZero()
        {
            HighSchool school = new HighSchool();

            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        public void TestHighSchool_CoursesEqualsZero()
        {
            HighSchool school = new HighSchool();

            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        public void TestAddStudent()
        {
            HighSchool school = new HighSchool();
            Student student = new Student("asd", 10000);

            school.AddStudent(student);

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddStudent_AddOneStudentTwoTimes()
        {
            HighSchool school = new HighSchool();
            Student student = new Student("asd", 10000);

            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            HighSchool school = new HighSchool();
            Student student1 = new Student("asd", 10000);
            Student student2 = new Student("qwe", 10001);
            school.AddStudent(student1);
            school.AddStudent(student2);
            school.RemoveStudent(student1);

            Assert.AreEqual(student2, school.Students[0]);
        }

        [TestMethod]
        public void TestAddCourse()
        {
            HighSchool school = new HighSchool();
            Course course = new Course();
            school.AddCourse(course);

            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void TestRemoveCourse()
        {
            HighSchool school = new HighSchool();
            Course course = new Course();
            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(0, school.Courses.Count);
        }
    }
}
