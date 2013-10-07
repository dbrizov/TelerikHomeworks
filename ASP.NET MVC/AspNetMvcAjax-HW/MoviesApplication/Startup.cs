using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesApplication.Startup))]
namespace MoviesApplication
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
