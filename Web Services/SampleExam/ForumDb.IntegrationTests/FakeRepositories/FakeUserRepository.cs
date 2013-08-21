using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumDb.Models;
using ForumDb.Repositories;

namespace ForumDb.IntegrationTests.FakeRepositories
{
    public class FakeUserRepository : IRepository<User>
    {
        public IList<User> Entities;

        public FakeUserRepository()
        {
            this.Entities = new List<User>();
            this.Entities.Add(new User());
        }

        public User Add(User item)
        {
            item.Id = this.Entities.Count;
            this.Entities.Add(item);

            return item;
        }

        public User GetById(int id)
        {
            return this.Entities[id];
        }

        public IQueryable<User> GetAll()
        {
            return this.Entities.Skip(1).AsQueryable();
        }

        public User Update(int id, User item)
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
