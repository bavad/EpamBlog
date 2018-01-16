using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using EpamPractice1.DAL.EF;

[assembly: OwinStartup(typeof(EpamPractice1.App_Start.Startup))]

namespace EpamPractice1.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.CreatePerOwinContext<BlogContext>(BlogContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}

