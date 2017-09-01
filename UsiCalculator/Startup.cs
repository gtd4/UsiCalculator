using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsiCalculator.Startup))]
namespace UsiCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
