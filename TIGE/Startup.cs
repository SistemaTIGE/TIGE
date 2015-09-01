using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TIGE.Startup))]
namespace TIGE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
