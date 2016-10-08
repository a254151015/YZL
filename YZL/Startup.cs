using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YZL.Startup))]
namespace YZL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
