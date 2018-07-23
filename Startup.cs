using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pry_Agencia_Viajes.Startup))]
namespace Pry_Agencia_Viajes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
