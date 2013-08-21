using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudentsDb.Repositories
{
    public interface IRepository<T>
    {
        T Add(T item);

        T GetById(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        T Update(int id, T item);

        void Delete(int id);
    }
}
