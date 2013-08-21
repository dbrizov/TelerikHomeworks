using System;
using System.Linq;
using System.Linq.Expressions;

namespace ForumDb.Repositories
{
    public interface IRepository<T>
    {
        T Add(T item);

        T GetById(int id);

        IQueryable<T> GetAll();

        T Update(int id, T item);

        void Delete(int id);
    }
}
