using System;
using System.Linq;
using StudentsDb.DataLayer;

namespace StudentsDb.Services.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public static SchoolModel CreateFromSchoolEntity(School entity)
        {
            SchoolModel model = new SchoolModel()
            {
                Id = entity.SchoolId,
                Name = entity.Name,
                Location = entity.Location
            };

            return model;
        }
    }
}