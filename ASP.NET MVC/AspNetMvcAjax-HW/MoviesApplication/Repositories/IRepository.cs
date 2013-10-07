using System;
using System.Linq;

namespace MoviesApplication.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
