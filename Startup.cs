using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHealth.Startup))]
namespace MyHealth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
