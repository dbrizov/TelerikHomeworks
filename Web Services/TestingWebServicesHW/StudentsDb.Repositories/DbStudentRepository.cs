using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using StudentsDb.DataLayer;

namespace StudentsDb.Repositories
{
    public class DbStudentRepository : IRepository<Student>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Student> studentEntities;

        public DbStudentRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext", "An instance of DbContext is required to use this repository.");
            }

            this.dbContext = dbContext;
            this.studentEntities = this.dbContext.Set<Student>();
        }

        public Student Add(Student item)
        {
            this.studentEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Student GetById(int id)
        {
            return this.studentEntities.Find(id);
        }

        public IQueryable<Student> GetAll()
        {
            return this.studentEntities;
        }

        public IQueryable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            var entities = this.studentEntities.Where(predicate);

            return entities;
        }

        public Student Update(int id, Student item)
        {
            var entity = this.studentEntities.Find(id);

            if (entity == null)
            {
                throw new NullReferenceException(
                    string.Format("A Student entity with id={0} does not exist in the Database", id));
            }

            entity.FirstName = item.FirstName;
            entity.Grade = item.Grade;
            entity.LastName = item.LastName;
            entity.Marks = item.Marks;
            entity.School = item.School;

            this.dbContext.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.studentEntities.Find(id);
            if (entity == null)
            {
                throw new NullReferenceException(
                    string.Format("A Student entity with id={0} does not exist in the Database", id));
            }

            this.studentEntities.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
