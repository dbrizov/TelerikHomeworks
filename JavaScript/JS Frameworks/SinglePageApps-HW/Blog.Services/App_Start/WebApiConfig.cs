using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Blog.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "TagsApi",
                routeTemplate: "api/tags/{tagId}/{action}",
                defaults: new
                {
                    controller = "tags",
                    tagId = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsCommentsApi",
                routeTemplate: "api/posts/{postId}/comment",
                defaults: new
                {
                    controller = "posts",
                    action = "comment"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApi",
                routeTemplate: "api/posts",
                defaults: new
                {
                    controller = "posts"
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
