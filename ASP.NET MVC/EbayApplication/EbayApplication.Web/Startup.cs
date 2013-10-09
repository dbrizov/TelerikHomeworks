using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EbayApplication.Web.Startup))]
namespace EbayApplication.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
