using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterAPI.Startup))]
namespace TwitterAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
