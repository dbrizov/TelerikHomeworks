using System;
using System.Linq;
using StudentsDb.DataLayer;

namespace StudentsDb.Services.Models
{
    public class MarkModel
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }

        public int StudentId { get; set; }

        public static MarkModel CreateFromMarkEntity(Mark entity)
        {
            MarkModel model = new MarkModel()
            {
                Id = entity.MarkId,
                Subject = entity.Subject,
                Value = entity.Value,
                StudentId = entity.StudentId
            };

            return model;
        }
    }
}