using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnstitchedClothes.Startup))]
namespace UnstitchedClothes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
