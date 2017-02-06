using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JamesAlcaraz.NlayeredAppDemo.Web.Startup))]
namespace JamesAlcaraz.NlayeredAppDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
