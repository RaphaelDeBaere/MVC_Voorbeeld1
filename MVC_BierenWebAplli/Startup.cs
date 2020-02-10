using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_BierenWebAplli.Startup))]
namespace MVC_BierenWebAplli
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
