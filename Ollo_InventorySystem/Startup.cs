using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ollo_InventorySystem.Startup))]
namespace Ollo_InventorySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
