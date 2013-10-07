using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Categories",
                url: "Categories/{action}/{id}",
                defaults: new
                {
                    controller = "Categories",
                    action = "All",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Books",
                url: "Books/{action}/{id}",
                defaults: new
                {
                    controller = "Books",
                    action = "All",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
