using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Repositories;

namespace Blog.IntegrationTests.FakeRepositories
{
    public class FakePostRepository : IRepository<Post>
    {
        public IList<Post> Entities;

        public FakePostRepository()
        {
            this.Entities = new List<Post>();
            this.Entities.Add(new Post());
        }

        public Post Add(Post item)
        {
            item.Id = this.Entities.Count;
            this.Entities.Add(item);

            return item;
        }

        public Post GetById(int id)
        {
            return this.Entities[id];
        }

        public IQueryable<Post> GetAll()
        {
            return this.Entities.Skip(1).AsQueryable();
        }

        public Post Update(int id, Post item)
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
