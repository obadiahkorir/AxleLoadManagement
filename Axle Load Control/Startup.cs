using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Axle_Load_Control.Startup))]
namespace Axle_Load_Control
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
