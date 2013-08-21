using System;
using System.Data.Entity;
using System.Linq;
using StudentsDb.DataLayer;

namespace StudentsDb.Repositories
{
    public class DbMarkRepository : IRepository<Mark>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Mark> markEntities;

        public DbMarkRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext", "An instance of DbContext is required to use this repository.");
            }

            this.dbContext = dbContext;
            this.markEntities = this.dbContext.Set<Mark>();
        }

        public Mark Add(Mark item)
        {
            this.markEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Mark GetById(int id)
        {
            return this.markEntities.Find(id);
        }

        public IQueryable<Mark> GetAll()
        {
            return this.markEntities;
        }

        public IQueryable<Mark> Find(System.Linq.Expressions.Expression<Func<Mark, bool>> predicate)
        {
            var entities = this.markEntities.Where(predicate);

            return entities;
        }

        public Mark Update(int id, Mark item)
        {
            var entity = this.markEntities.Find(id);

            if (entity == null)
            {
                throw new NullReferenceException(
                    string.Format("A Mark entity with id={0} does not exist in the Database", id));
            }

            entity.Student = item.Student;
            entity.Subject = item.Subject;
            entity.Value = item.Value;

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.markEntities.Find(id);

            if (entity == null)
            {
                throw new NullReferenceException(
                    string.Format("A Mark entity with id={0} does not exist in the Database", id));
            }

            this.markEntities.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
