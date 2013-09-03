using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Blog.Models;
using Blog.Repositories;
using Blog.Services.Extensions;
using Blog.Services.Models;
using System.Net.Http;
using System.Net;

namespace Blog.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Post> postRepository;
        private readonly IRepository<Tag> tagRepository;
        private readonly IRepository<Comment> commentRepository;

        public PostsController(
            IRepository<User> userRepository,
            IRepository<Post> postRepository,
            IRepository<Tag> tagRepository,
            IRepository<Comment> commentRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
            this.commentRepository = commentRepository;
        }

        [HttpPost]
        public HttpResponseMessage CreatePost([FromBody]PostModel postModel, [FromUri]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var user = this.userRepository
                        .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("The user is not logged in");
                    }

                    if (postModel.Title == null)
                    {
                        throw new InvalidOperationException("The title of the post can't be null");
                    }

                    if (postModel.Text == null)
                    {
                        throw new InvalidOperationException("The text of the post can't be null");
                    }

                    string postTitleToLower = postModel.Title.ToLower();
                    string[] tagsFromTitle = postTitleToLower.Split(
                        new char[] { ' ', '.', ',', '!', '?', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);

                    var tagEntities = this.tagRepository.GetAll().ToList();

                    Post newPostEntity = new Post();
                    newPostEntity.Title = postModel.Title;
                    newPostEntity.Text = postModel.Text;
                    newPostEntity.User = user;
                    newPostEntity.PostDate = DateTime.Now;

                    if (postModel.Tags != null)
                    {
                        foreach (var tagFromTitle in tagsFromTitle)
                        {
                            var existingTag = tagEntities.FirstOrDefault(t => t.Name == tagFromTitle);
                            if (existingTag == null)
                            {
                                var newTagEntity = new Tag();
                                newTagEntity.Name = tagFromTitle;

                                this.tagRepository.Add(newTagEntity);
                            }
                            else
                            {
                                newPostEntity.Tags.Add(existingTag);
                            }
                        }

                        foreach (var tag in postModel.Tags)
                        {
                            string tagToLower = tag.ToLower();

                            var existingTag = tagEntities.FirstOrDefault(t => t.Name == tagToLower);
                            if (existingTag == null)
                            {
                                var newTagEntity = new Tag();
                                newTagEntity.Name = tagToLower;

                                this.tagRepository.Add(newTagEntity);
                            }
                            else
                            {
                                newPostEntity.Tags.Add(existingTag);
                            }
                        }
                    }

                    this.postRepository.Add(newPostEntity);

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                        new
                        {
                            title = newPostEntity.Title,
                            id = newPostEntity.Id
                        });

                    return response;
                });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetAll([FromUri]string sessionKey)
        {
            var user = this.userRepository
                .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user is not logged in");
            }

            var postModels = new List<PostModel>();
            var postEntities = this.postRepository.GetAll().ToList();

            foreach (var postEntity in postEntities)
            {
                postModels.Add(PostModel.CreateFromPostEntity(postEntity));
            }

            return postModels.OrderByDescending(p => p.PostDate).AsQueryable();
        }

        [HttpGet]
        public IQueryable<PostModel> GetPage([FromUri]int page, [FromUri]int count, [FromUri]string sessionKey)
        {
            var posts = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);

            return posts; // They are already sorted;
        }

        [HttpGet]
        public IQueryable<PostModel> GetByKeywork([FromUri]string keyword, [FromUri]string sessionKey)
        {
            var posts = this.GetAll(sessionKey)
                .Where(post => post.Title.Contains(keyword));

            return posts.OrderByDescending(post => post.PostDate);
        }

        [HttpGet]
        public IQueryable<PostModel> GetByTags([FromUri]string tags, [FromUri]string sessionKey)
        {
            var splitedTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var posts = this.GetAll(sessionKey)
                .Where(post => post.Tags.ContainsAll(splitedTags));

            return posts.OrderByDescending(p => p.PostDate);
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage CommentPost([FromBody]CommentModel commentModel, [FromUri]int postId, [FromUri]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var user = this.userRepository
                        .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("The user is not logged in");
                    }

                    var post = this.postRepository
                        .GetAll().Where(p => p.Id == postId).FirstOrDefault();

                    if (post == null)
                    {
                        throw new InvalidOperationException("There is no post with id=" + postId);
                    }

                    if (commentModel.Text == null)
                    {
                        throw new InvalidOperationException("The comment can't be empty");
                    }

                    var newCommentEntity = new Comment()
                    {
                        Post = post,
                        PostDate = DateTime.Now,
                        Text = commentModel.Text,
                        User = user
                    };

                    this.commentRepository.Add(newCommentEntity);

                    var response = this.Request.CreateResponse(HttpStatusCode.OK, (object)null);
                    return response;
                });

            return responseMsg;
        }
    }
}
