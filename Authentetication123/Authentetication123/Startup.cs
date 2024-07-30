using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authentetication123.Startup))]
namespace Authentetication123
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
