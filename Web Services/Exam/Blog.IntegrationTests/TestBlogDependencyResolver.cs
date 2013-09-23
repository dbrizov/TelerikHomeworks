using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Blog.Services.Controllers;
using Blog.IntegrationTests.FakeRepositories;

namespace Blog.IntegrationTests
{
    class TestBlogDependencyResolver<T> : IDependencyResolver
    {
        public IRepository<T> Repository { get; set; }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(this.Repository as IRepository<User>);
            }
            else if (serviceType == typeof(PostsController))
            {
                var fakeUserRepo = new FakeUserRepository();
                var fakePostRepo = new FakePostRepository();
                var fakeTagRepo = new FakeTagRepository();
                var fakeCommentRepo = new FakeCommentRepository();

                return new PostsController(
                    fakeUserRepo,
                    fakePostRepo,
                    fakeTagRepo,
                    fakeCommentRepo);
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
