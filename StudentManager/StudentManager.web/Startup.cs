using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using StudentManager.DomainModels;
using StudentMAnager.DAL;

[assembly: OwinStartupAttribute(typeof(StudentManager.web.Startup))]
namespace StudentManager.web
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext(() => new ApplicationDbContext());
            app.CreatePerOwinContext<UserStore<ApplicationUser>>((opt, cont) => new UserStore<ApplicationUser>(cont.Get<ApplicationDbContext>()));
            app.CreatePerOwinContext<UserManager<ApplicationUser>>(
                (opt, cont) => new UserManager<ApplicationUser>(cont.Get<UserStore<ApplicationUser>>()));
            app.CreatePerOwinContext<SignInManager<ApplicationUser, string>>(
                (opt, cont) =>
                    new SignInManager<ApplicationUser, string>(cont.Get<UserManager<ApplicationUser>>(), cont.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

        }



    }
}
