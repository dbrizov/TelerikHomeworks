using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using ForumDb.Models;
using ForumDb.Repositories;
using ForumDb.Services.Controllers;

namespace ForumDb.IntegrationTests
{
    class TestDependencyResolver<T> : IDependencyResolver
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
