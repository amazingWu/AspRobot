using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(robot.Startup))]
namespace robot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
