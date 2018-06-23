using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsKob.Startup))]
namespace EventsKob
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
