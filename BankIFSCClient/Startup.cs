using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankIFSCClient.Startup))]
namespace BankIFSCClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
