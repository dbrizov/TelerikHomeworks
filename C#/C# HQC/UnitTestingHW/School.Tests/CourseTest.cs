using School;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace School.Tests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourse_DefaultConstructor()
        {
            Course course = new Course();

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        public void TestCourse_NormalArgumentsGiven()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 15; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);

            Assert.AreEqual(15, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourse_StudentsAreNull()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourse_StudentsCountBiggerThanCourseLimit()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 31; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddStudent_StudentIsNull()
        {
            Course course = new Course();
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddStudent_CourseIsFull()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 30; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
            course.AddStudent(new Student("qwe", 50000));
        }

        [TestMethod]
        public void TestAddStudent_CourseIsNotFull1()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 29; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
            course.AddStudent(new Student("qwe", 50000));

            Assert.AreEqual(30, course.Students.Count);
        }

        [TestMethod]
        public void TestAddStudent_CourseIsNotFull2()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 29; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
            Student student = new Student("qwe", 50000);
            course.AddStudent(student);

            Assert.AreEqual(student, course.Students[29]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveStudent_StudentIsNull()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRemoveStudent_CourseIsEmpty()
        {
            Course course = new Course();
            course.RemoveStudent(new Student("asd", 10000));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRemoveStudent_StudentNotInTheCourse()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
            course.RemoveStudent(new Student("asd", 50000));
        }

        [TestMethod]
        public void TestRemoveStudent_SuccessfullyRemoved()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student("asd", 10000 + i));
            }

            Course course = new Course(students);
            course.RemoveStudent(new Student("asd", 10000));

            Assert.AreEqual(false, course.Students.Contains(new Student("asd", 10000)));
        }
    }
}
