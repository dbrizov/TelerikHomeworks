using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaptopSystem.Web.Startup))]
namespace LaptopSystem.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
