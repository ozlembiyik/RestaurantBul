using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantBul.Startup))]
namespace RestaurantBul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
