using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Waterbuffalortours.Startup))]
namespace Waterbuffalortours
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
