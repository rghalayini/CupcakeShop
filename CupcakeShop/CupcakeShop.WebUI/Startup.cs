using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CupcakeShop.WebUI.Startup))]
namespace CupcakeShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
