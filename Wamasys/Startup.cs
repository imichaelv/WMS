using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wamasys.Startup))]
namespace Wamasys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
