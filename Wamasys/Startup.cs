using Microsoft.Owin;
using Owin;
using System.Globalization;
using System.Threading;

[assembly: OwinStartupAttribute(typeof(Wamasys.Startup))]
namespace Wamasys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            ConfigureAuth(app);
        }
    }
}