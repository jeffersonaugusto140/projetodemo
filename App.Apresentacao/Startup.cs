using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.Apresentacao.Startup))]
namespace App.Apresentacao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
