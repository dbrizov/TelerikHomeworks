using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsDb.DataLayer;
using StudentsDb.Repositories;

namespace StudentsDb.Services.Tests.FakeRepositories
{
    public class FakeStudentRepository : IRepository<Student>
    {
        public List<Student> Entities { get; set; }

        public FakeStudentRepository()
        {
            this.Entities = new List<Student>();
        }

        public Student Add(Student item)
        {
            this.Entities.Add(item);
            return item;
        }

        public Student GetById(int id)
        {
            return this.Entities[id];
        }

        public IQueryable<Student> GetAll()
        {
            return this.Entities.AsQueryable();
        }

        public IQueryable<Student> Find(System.Linq.Expressions.Expression<Func<Student, bool>> predicate)
        {
            return this.Entities.AsQueryable().Where(predicate);
        }

        public Student Update(int id, Student item)
        {
            this.Entities[id] = item;
            return item;
        }

        public void Delete(int id)
        {
            this.Entities.RemoveAt(id);
        }
    }
}
