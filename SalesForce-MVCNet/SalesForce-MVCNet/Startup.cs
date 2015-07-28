using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesForce_MVCNet.Startup))]
namespace SalesForce_MVCNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
