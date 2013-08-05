namespace University.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using University.Data;
    using University.Models;

    public sealed class Configuration : DbMigrationsConfiguration<UniversityContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UniversityContext context)
        {
            Homework homework = new Homework();
            homework.Content = "some content";
            homework.TimeSent = DateTime.Now;

            context.Homeworks.AddOrUpdate(h => h.Content, homework);

            Student student = new Student();
            student.Name = "gosho";
            student.Number = 456;
            student.Homework = homework;

            context.Students.AddOrUpdate(s => s.Name, student);
            homework.Students.Add(student);

            Course course = new Course();
            course.Description = "some description";
            course.Materials = null;
            course.Homework = homework;

            context.Courses.AddOrUpdate(c => c.Description, course);
            homework.Courses.Add(course);

            student.Courses.Add(course);
            course.Students.Add(student);

            context.SaveChanges();
        }
    }
}
