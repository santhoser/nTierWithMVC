using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nTierWithMVC.Web.Startup))]
namespace nTierWithMVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
