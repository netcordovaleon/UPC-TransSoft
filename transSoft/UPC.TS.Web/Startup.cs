using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UPC.TS.Web.Startup))]
namespace UPC.TS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
