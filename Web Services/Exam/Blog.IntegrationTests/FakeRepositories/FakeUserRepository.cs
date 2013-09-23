using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Repositories;

namespace Blog.IntegrationTests.FakeRepositories
{
    public class FakeUserRepository : IRepository<User>
    {
        public IList<User> Entities;

        public FakeUserRepository()
        {
            this.Entities = new List<User>();
            this.Entities.Add(new User()
            {
                DisplayName = "KrisoMadafaka",
                Username = "kristiqnchooo",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e",
                SessionKey = "1zIzcHNYWhSKnWVrGNpBLxOzDDLPRMbHMeMjklumYmodzRTgAH"
            });
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
            return this.Entities.AsQueryable();
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
