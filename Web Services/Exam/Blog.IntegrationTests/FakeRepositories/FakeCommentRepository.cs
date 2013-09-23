using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.IntegrationTests.FakeRepositories
{
    public class FakeCommentRepository : IRepository<Comment>
    {
        public IList<Comment> Entities;

        public FakeCommentRepository()
        {
            this.Entities = new List<Comment>();
            this.Entities.Add(new Comment());
        }

        public Comment Add(Comment item)
        {
            item.Id = this.Entities.Count;
            this.Entities.Add(item);

            return item;
        }

        public Comment GetById(int id)
        {
            return this.Entities[id];
        }

        public IQueryable<Comment> GetAll()
        {
            return this.Entities.Skip(1).AsQueryable();
        }

        public Comment Update(int id, Comment item)
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
