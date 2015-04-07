using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaboratorioCINAPFinal.Startup))]
namespace LaboratorioCINAPFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
