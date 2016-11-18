using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC465.Startup))]
namespace MVC465
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}