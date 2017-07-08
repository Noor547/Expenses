using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpMngr.Startup))]
namespace ExpMngr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
