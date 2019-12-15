using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatJobsity.Startup))]
namespace ChatJobsity
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
