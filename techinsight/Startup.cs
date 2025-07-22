using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(techinsight.Startup))]
namespace techinsight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
