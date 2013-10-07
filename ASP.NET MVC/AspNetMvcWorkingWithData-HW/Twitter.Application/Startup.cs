using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twitter.Application.Startup))]
namespace Twitter.Application
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
