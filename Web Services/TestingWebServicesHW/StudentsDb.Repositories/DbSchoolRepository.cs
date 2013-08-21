using System;
using System.Data.Entity;
using System.Linq;
using StudentsDb.DataLayer;

namespace StudentsDb.Repositories
{
    public class DbSchoolRepository : IRepository<School>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<School> schoolEntities;

        public DbSchoolRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext", "An instance of DbContext is required to use this repository.");
            }

            this.dbContext = dbContext;
            this.schoolEntities = this.dbContext.Set<School>();
        }

        public School Add(School item)
        {
            this.schoolEntities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public School GetById(int id)
        {
            return this.schoolEntities.Find(id);
        }

        public IQueryable<School> GetAll()
        {
            return this.schoolEntities;
        }

        public IQueryable<School> Find(System.Linq.Expressions.Expression<Func<School, bool>> predicate)
        {
            var entities = this.schoolEntities.Where(predicate);

            return entities;
        }

        public School Update(int id, School item)
        {
            var entity = this.schoolEntities.Find(id);

            if (entity == null)
            {
                throw new NullReferenceException(
                    string.Format("A School entity with id={0} does not exist in the Database", id));
            }

            entity.Location = item.Location;
            entity.Name = item.Name;
            entity.Students = item.Students;

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.schoolEntities.Find(id);

            if (entity == null)
            {
                throw new NullReferenceException(
                    string.Format("A School entity with id={0} does not exist in the Database", id));
            }

            this.schoolEntities.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
