using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(updatetabledemo.Startup))]
namespace updatetabledemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
