using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ForumDb.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "CategoriesApi",
                routeTemplate: "api/categories/{action}",
                defaults: new
                {
                    controller = "categories",
                    action = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApi",
                routeTemplate: "api/posts/{postId}/{action}",
                defaults: new
                {
                    controller = "posts"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsCreateApi",
                routeTemplate: "api/posts/create",
                defaults: new
                {
                    controller = "posts",
                    action = "create"
                }
            );

            // api/threads/{threadId}/posts?sessionKey=***
            config.Routes.MapHttpRoute(
                name: "ThreadsPostsApi",
                routeTemplate: "api/threads/{threadId}/posts",
                defaults: new
                {
                    controller = "threads",
                    action = "posts"
                }
            );

            // api/threads/{action}?sessionKey=***&params
            config.Routes.MapHttpRoute(
                name: "ThreadsApi",
                routeTemplate: "api/threads/{action}",
                defaults: new
                {
                    controller = "threads",
                    action = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
