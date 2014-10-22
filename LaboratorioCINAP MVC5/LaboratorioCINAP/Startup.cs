using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaboratorioCINAP.Startup))]
namespace LaboratorioCINAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
