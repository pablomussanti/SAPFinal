using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Decopack.Web.Startup))]
namespace Decopack.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
