using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeminarMVC.Startup))]
namespace SeminarMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
