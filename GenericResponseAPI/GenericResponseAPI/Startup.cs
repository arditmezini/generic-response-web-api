using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GenericResponseAPI.Startup))]

namespace GenericResponseAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
