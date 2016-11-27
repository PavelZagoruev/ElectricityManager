using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KP.Startup))]
namespace KP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
