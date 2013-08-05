using System;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using University.Models;

namespace University.Data
{
    public class HomeworkMappings : EntityTypeConfiguration<Homework>
    {
        public HomeworkMappings()
        {
            this.HasKey(x => x.HomeworkId);
            this.Property(x => x.Content).IsRequired().IsUnicode();
            this.Property(x => x.TimeSent).IsRequired();
        }
    }
}
