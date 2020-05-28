using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(plantillaMVC.Startup))]
namespace plantillaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
