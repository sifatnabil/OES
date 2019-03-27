using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OES.Startup))]
namespace OES
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
