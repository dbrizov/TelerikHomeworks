using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.Models;
using Blog.Repositories;
using Blog.Services.Models;

namespace Blog.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        private readonly IRepository<Tag> tagRepository;
        private readonly IRepository<User> userRepository;

        public TagsController(IRepository<Tag> tagRepository, IRepository<User> userRepository)
        {
            this.tagRepository = tagRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IQueryable<TagModel> GetAll([FromUri]string sessionKey)
        {
            var user = this.userRepository
                        .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user is not logged in");
            }

            var tagModels = this.tagRepository.GetAll().Select(TagModel.FromTagEntity());

            return tagModels.OrderBy(tag => tag.Name);
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<PostModel> GetByTagId([FromUri]int tagId, [FromUri]string sessionKey)
        {
            var user = this.userRepository
                        .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user is not logged in");
            }

            var tag = this.tagRepository.GetById(tagId);

            if (tag == null)
            {
                throw new InvalidOperationException("There is no tag with id=" + tagId);
            }

            var postModels = new List<PostModel>();
            var postEntities = tag.Posts;

            foreach (var postEntity in postEntities)
            {
                postModels.Add(PostModel.CreateFromPostEntity(postEntity));
            }

            return postModels.OrderByDescending(p => p.PostDate).AsQueryable();
        }
    }
}
