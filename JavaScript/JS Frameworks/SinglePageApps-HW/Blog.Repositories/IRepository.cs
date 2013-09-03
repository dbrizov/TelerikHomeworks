using System;
using System.Linq;

namespace Blog.Repositories
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
