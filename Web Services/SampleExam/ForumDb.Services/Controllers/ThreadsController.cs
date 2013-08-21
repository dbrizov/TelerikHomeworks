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
    public class ThreadsController : BaseApiController
    {
        private readonly IRepository<Thread> threadRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Category> categoryRepository;

        public ThreadsController(
            IRepository<Thread> threadRepository,
            IRepository<User> userRepository,
            IRepository<Category> categoryRepository)
        {
            this.threadRepository = threadRepository;
            this.userRepository = userRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateThread(ThreadModel model, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var user = this.userRepository
                    .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

                if (user == null)
                {
                    throw new InvalidOperationException("The user is not logged in");
                }

                if (model.Title == null)
                {
                    throw new ArgumentNullException("The title can't be null");
                }

                if (model.Content == null)
                {
                    throw new ArgumentNullException("The content can't be null");
                }

                Thread newThread = new Thread()
                {
                    Content = model.Content,
                    Creator = user,
                    DateCreated = model.DateCreated,
                    Title = model.Title
                };

                foreach (var category in model.Categories)
                {
                    var categoryEntity = this.categoryRepository
                        .GetAll().Where(cat => cat.Name.ToLower() == category.ToLower()).FirstOrDefault();

                    if (categoryEntity == null)
                    {
                        categoryEntity = new Category();
                        categoryEntity.Name = category;

                        this.categoryRepository.Add(categoryEntity);
                    }

                    categoryEntity.Threads.Add(newThread);
                    newThread.Categories.Add(categoryEntity);
                }

                this.threadRepository.Add(newThread);

                var response = this.Request.CreateResponse(HttpStatusCode.Created,
                    new
                    {
                        id = newThread.Id,
                        createdBy = user.Nickname
                    });

                return response;
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<ThreadModel> GetAll(string sessionKey)
        {
            var user = this.userRepository
                .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user needs to be logged in to view his threads");
            }

            var threadModels = new List<ThreadModel>();
            var threadEntities = this.threadRepository.GetAll().ToList();

            foreach (var threadEntity in threadEntities)
            {
                threadModels.Add(ThreadModel.CreateFromThreadEntity(threadEntity));
            }

            return threadModels.OrderByDescending(thr => thr.DateCreated).AsQueryable();
        }

        [HttpGet]
        public IQueryable<ThreadModel> GetByCategory(string category, string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Where(thr => thr.Categories.Any(cat => cat.ToLower() == category.ToLower()));

            return models;
        }

        [HttpGet]
        public IQueryable<ThreadModel> GetPage(int page, int count, string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);

            return models;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<PostModel> GetPost(int threadId, string sessionKey)
        {
            var user = this.userRepository
                .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user is not logged in");
            }

            var threadEnitity = this.threadRepository
                .GetAll().Where(th => th.Id == threadId).FirstOrDefault();

            if (threadEnitity != null)
            {
                var posts = threadEnitity.Posts;
                var models = new List<PostModel>();

                foreach (var post in posts)
                {
                    models.Add(PostModel.CreateFromPostEnitity(post));
                }

                return models.OrderByDescending(p => p.PostDate).AsQueryable();
            }

            return null;
        }
    }
}
