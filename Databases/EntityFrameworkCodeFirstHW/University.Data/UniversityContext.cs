using System;
using System.Data.Entity;
using System.Linq;
using University.Models;

namespace University.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
            : base("UniversityDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMappings());
            modelBuilder.Configurations.Add(new CourseMappings());
            modelBuilder.Configurations.Add(new HomeworkMappings());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}
