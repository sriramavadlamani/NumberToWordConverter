using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NumberToWordConverter.Startup))]
namespace NumberToWordConverter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
