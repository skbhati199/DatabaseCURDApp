using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatabaseCURDApp.Startup))]
namespace DatabaseCURDApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  ConfigureAuth(app);
        }
    }
}
