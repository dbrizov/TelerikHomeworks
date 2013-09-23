using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Blog.Data;
using Blog.Services.Controllers;
using Blog.Repositories;

namespace Blog.Services.DependencyResolvers
{
    public class BlogDbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                var dbContext = new BlogContext();
                var repository = new EfUserRepository(dbContext);

                return new UsersController(repository);
            }
            else if (serviceType == typeof(PostsController))
            {
                var dbContext = new BlogContext();
                var postRepository = new EfPostRepository(dbContext);
                var userRepository = new EfUserRepository(dbContext);
                var tagRepository = new EfTagRepository(dbContext);
                var commentRepository = new EfCommentRepository(dbContext);

                return new PostsController(
                    userRepository,
                    postRepository,
                    tagRepository,
                    commentRepository);
            }
            else if (serviceType == typeof(TagsController))
            {
                var dbContext = new BlogContext();
                var tagRepository = new EfTagRepository(dbContext);
                var userRepository = new EfUserRepository(dbContext);

                return new TagsController(tagRepository, userRepository);
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