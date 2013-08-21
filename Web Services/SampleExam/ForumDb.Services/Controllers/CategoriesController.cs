using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ForumDb.Models;
using ForumDb.Repositories;
using ForumDb.Services.Models;

namespace ForumDb.Services.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Thread> threadRepository;
        private readonly IRepository<User> userRepository;

        public CategoriesController(
            IRepository<Category> categoryRepository,
            IRepository<Thread> threadRepository,
            IRepository<User> userRepository)
        {
            this.categoryRepository = categoryRepository;
            this.threadRepository = threadRepository;
            this.userRepository = userRepository;
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage PostCategory(CategoryModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    if (model.Name == null)
                    {
                        throw new InvalidOperationException("The name of the category can't be null");
                    }

                    Category category = new Category();
                    category.Name = model.Name;

                    var threadTitles = model.ThreadTitles;
                    var threadEntities = this.threadRepository.GetAll();
                    foreach (var threadTitle in threadTitles)
                    {
                        var threadEntity = threadEntities.FirstOrDefault(th => th.Title == threadTitle);
                        category.Threads.Add(threadEntity);
                    }

                    this.categoryRepository.Add(category);

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, new { id = category.Id });
                    return response;
                });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<string> GetAll(string sessionKey)
        {
            var user = this.userRepository
                .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user is not logged in");
            }

            var categories = this.categoryRepository.GetAll().Select(cat => cat.Name);
            return categories;
        }
    }
}
