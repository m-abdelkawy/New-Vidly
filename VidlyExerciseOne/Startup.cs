using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyExerciseOne.Startup))]
namespace VidlyExerciseOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
