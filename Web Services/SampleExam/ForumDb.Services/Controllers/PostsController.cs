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
    public class PostsController : BaseApiController
    {
        private readonly IRepository<Post> postRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Thread> threadRepository;
        private readonly IRepository<Vote> voteRepository;
        private readonly IRepository<Comment> commentRepository;

        public PostsController(
            IRepository<Post> postRepository,
            IRepository<User> userRepository,
            IRepository<Thread> threadRepository,
            IRepository<Vote> voteRepository,
            IRepository<Comment> commentRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
            this.threadRepository = threadRepository;
            this.voteRepository = voteRepository;
            this.commentRepository = commentRepository;
        }

        [HttpGet]
        public IQueryable<PostModel> GetAll(string sessionKey)
        {
            var user = this.userRepository
                .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("The user is not logged in");
            }

            var posts = this.postRepository.GetAll().ToList();
            var models = new List<PostModel>();

            foreach (var post in posts)
            {
                models.Add(PostModel.CreateFromPostEnitity(post));
            }

            return models.OrderByDescending(p => p.PostDate).AsQueryable();
        }

        [HttpGet]
        public IQueryable<PostModel> GetPage(int page, int count, string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);

            return models;
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreatePost([FromBody]PostCreateModel model, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var user = this.userRepository
                        .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("The user is not logged in");
                    }

                    var thread = this.threadRepository
                        .GetAll().Where(thr => thr.Id == model.ThreadId).FirstOrDefault();

                    if (thread == null)
                    {
                        throw new InvalidOperationException("There is no thread with such an id");
                    }

                    var newPost = new Post()
                    {
                        Content = model.Content,
                        PostDate = model.PostDate,
                        User = user,
                        Thread = thread
                    };

                    this.postRepository.Add(newPost);

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                        new
                        {
                            id = newPost.Id,
                            postedBy = user.Nickname
                        });

                    return response;
                });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("vote")]
        public HttpResponseMessage VotePost([FromBody]VoteModel model, int postId, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var user = this.userRepository
                        .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("The user is not logged in");
                    }

                    if (model.Value < 0 || model.Value > 5)
                    {
                        throw new ArgumentOutOfRangeException("The vote.value must be in range [0, 5] inclusive");
                    }

                    var post = this.postRepository.GetById(postId);
                    if (post == null)
                    {
                        throw new InvalidOperationException("There is not vote with id=" + postId);
                    }

                    Vote newVote = new Vote()
                    {
                        Post = post,
                        User = user,
                        Value = model.Value
                    };

                    post.Votes.Add(newVote);
                    this.voteRepository.Add(newVote);

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                        new
                        {
                            id = newVote.Id,
                            votedBy = user.Nickname,
                            value = newVote.Value
                        });

                    return response;
                });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("comment")]
        public HttpResponseMessage CommentPost([FromBody]CommentModel model, int postId, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var user = this.userRepository
                    .GetAll().Where(usr => usr.SessionKey == sessionKey).FirstOrDefault();

                if (user == null)
                {
                    throw new InvalidOperationException("The user is not logged in");
                }

                if (model.Content == null)
                {
                    throw new ArgumentOutOfRangeException("The comment content can't be null");
                }

                var post = this.postRepository.GetById(postId);
                if (post == null)
                {
                    throw new InvalidOperationException("There is not vote with id=" + postId);
                }

                Comment newComment = new Comment()
                {
                    CommentDate = model.CommentDate,
                    Content = model.Content,
                    User = user,
                    Post = post
                };

                post.Comments.Add(newComment);
                this.commentRepository.Add(newComment);

                var response = this.Request.CreateResponse(HttpStatusCode.Created,
                    new
                    {
                        id = newComment.Id,
                        commentedBy = user.Nickname,
                        content = newComment.Content
                    });

                return response;
            });

            return responseMsg;
        }
    }
}
