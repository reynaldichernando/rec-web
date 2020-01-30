using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Binus.SampleWebAPI.Web.Startup))]
namespace Binus.SampleWebAPI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
