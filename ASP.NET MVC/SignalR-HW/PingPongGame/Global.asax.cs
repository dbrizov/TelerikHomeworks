using System;
using System.Linq;
using System.Web.Routing;

namespace PingPongGame
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHubs();
        }
    }
}