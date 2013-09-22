using System;
using System.Data.Entity;
using System.Linq;

namespace UploadZip.Models
{
    public class FilesDbContext : DbContext
    {
        public FilesDbContext()
            : base("FilesDb")
        {

        }

        public DbSet<File> Files { get; set; }
    }
}