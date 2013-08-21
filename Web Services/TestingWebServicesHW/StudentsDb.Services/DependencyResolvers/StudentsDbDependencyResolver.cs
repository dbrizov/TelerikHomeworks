using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StudentsDb.DataLayer;
using StudentsDb.Repositories;
using StudentsDb.Services.Controllers;

namespace StudentsDb.Services.DependencyResolvers
{
    public class StudentsDbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                var context = new StudentsDbEntities();
                var repository = new DbStudentRepository(context);

                return new StudentsController(repository);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                var context = new StudentsDbEntities();
                var repository = new DbSchoolRepository(context);

                return new SchoolsController(repository);
            }
            else if (serviceType == typeof(MarksController))
            {
                var context = new StudentsDbEntities();
                var repository = new DbMarkRepository(context);

                return new MarksController(repository);
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