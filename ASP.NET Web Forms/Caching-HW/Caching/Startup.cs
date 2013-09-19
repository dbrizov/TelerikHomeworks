using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caching.Startup))]
namespace Caching
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
