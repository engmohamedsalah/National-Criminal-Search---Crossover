using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NationalCriminal.Startup))]
namespace NationalCriminal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
