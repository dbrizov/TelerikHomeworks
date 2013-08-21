using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using ForumDb.Data;
using ForumDb.Models;
using ForumDb.Repositories;
using ForumDb.Services.Controllers;

namespace ForumDb.Services.DependencyResolvers
{
    public class ForumDbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                var dbContext = new ForumDbContext();
                var repository = new DbUserRepository(dbContext);

                return new UsersController(repository);
            }
            else if (serviceType == typeof(ThreadsController))
            {
                var dbContext = new ForumDbContext();
                var threadRepository = new DbThreadRepository(dbContext);
                var userRepository = new DbUserRepository(dbContext);
                var categoryRepository = new DbCategoryRepository(dbContext);

                return new ThreadsController(
                    threadRepository,
                    userRepository,
                    categoryRepository);
            }
            else if (serviceType == typeof(CategoriesController))
            {
                var dbContext = new ForumDbContext();
                var categoryRepository = new DbCategoryRepository(dbContext);
                var threadRepository = new DbThreadRepository(dbContext);
                var userRepository = new DbUserRepository(dbContext);

                return new CategoriesController(
                    categoryRepository,
                    threadRepository,
                    userRepository);
            }
            else if (serviceType == typeof(PostsController))
            {
                var dbContext = new ForumDbContext();
                var postRepository = new DbPostRepository(dbContext);
                var userRepository = new DbUserRepository(dbContext);
                var threadRepository = new DbThreadRepository(dbContext);
                var voteRepository = new DbVoteRepository(dbContext);
                var commentRepository = new DbCommentRepository(dbContext);

                return new PostsController(
                    postRepository,
                    userRepository,
                    threadRepository,
                    voteRepository,
                    commentRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}