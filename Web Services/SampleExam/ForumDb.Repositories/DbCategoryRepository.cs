using System;
using System.Data.Entity;
using System.Linq;
using ForumDb.Models;

namespace ForumDb.Repositories
{
    public class DbCategoryRepository : IRepository<Category>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Category> categoryEnitities;

        public DbCategoryRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.categoryEnitities = this.dbContext.Set<Category>();
        }

        public Category Add(Category item)
        {
            this.categoryEnitities.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public Category GetById(int id)
        {
            return this.categoryEnitities.Find(id);
        }

        public IQueryable<Category> GetAll()
        {
            return this.categoryEnitities;
        }

        public Category Update(int id, Category item)
        {
            var category = this.categoryEnitities.Find(id);
            if (category != null)
            {
                category.Name = item.Name;
                category.Threads = item.Threads;

                this.dbContext.SaveChanges();
            }

            return category;
        }

        public void Delete(int id)
        {
            var category = this.categoryEnitities.Find(id);
            if (category != null)
            {
                this.categoryEnitities.Remove(category);
                this.dbContext.SaveChanges();
            }
        }
    }
}
