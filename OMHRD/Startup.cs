using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OMHRD.Startup))]
namespace OMHRD
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
