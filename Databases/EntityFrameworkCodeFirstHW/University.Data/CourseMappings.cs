using System;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using University.Models;

namespace University.Data
{
    public class CourseMappings : EntityTypeConfiguration<Course>
    {
        public CourseMappings()
        {
            this.HasKey(x => x.CourseId);
            this.Property(x => x.Description).IsRequired().IsUnicode();
            this.Property(x => x.Materials).IsOptional().IsUnicode();
            this.Property(x => x.HomeworkId).IsOptional();
        }
    }
}
