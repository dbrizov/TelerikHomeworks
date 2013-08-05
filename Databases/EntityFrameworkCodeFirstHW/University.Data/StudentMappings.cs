using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using University.Models;

namespace University.Data
{
    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(x => x.StudentId);
            this.Property(x => x.Name).IsRequired().IsUnicode();
            this.Property(x => x.Number).IsRequired();
            this.Property(x => x.HomeworkId).IsOptional();
        }
    }
}
