using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.IntegrationTests.FakeRepositories
{
    public class FakeTagRepository : IRepository<Tag>
    {
        public IList<Tag> Entities;

        public FakeTagRepository()
        {
            this.Entities = new List<Tag>();
            this.Entities.Add(new Tag());
        }

        public Tag Add(Tag item)
        {
            item.Id = this.Entities.Count;
            this.Entities.Add(item);

            return item;
        }

        public Tag GetById(int id)
        {
            return this.Entities[id];
        }

        public IQueryable<Tag> GetAll()
        {
            return this.Entities.Skip(1).AsQueryable();
        }

        public Tag Update(int id, Tag item)
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
