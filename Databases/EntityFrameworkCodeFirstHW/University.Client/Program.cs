using System;
using System.Linq;
using System.Data.Entity;
using University.Models;
using University.Data;
using University.Data.Migrations;

namespace University.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<UniversityContext, Configuration>());

            UniversityContext universityContext = new UniversityContext();
            using (universityContext)
            {
                Student student = new Student();
                student.Name = "pesho";
                student.Number = 123;
                student.Homework = null;

                universityContext.Students.Add(student);

                Course course = new Course();
                course.Description = "desc";
                course.Materials = "mats";
                course.Homework = null;

                universityContext.Courses.Add(course);

                student.Courses.Add(course);
                course.Students.Add(student);

                universityContext.SaveChanges();

                Console.WriteLine("Ready!");
            }
        }
    }
}
