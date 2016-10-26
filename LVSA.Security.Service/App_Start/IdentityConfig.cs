using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using LVSA.Security.Service.Models;
using LVSA.Security.Infrastructure.CrossCutting.Identity;
using LVSA.Security.Infrastructure.CrossCutting.Identity.DbContext;

namespace LVSA.Security.Service
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<AppIdentityUser>
    {
        public ApplicationUserManager(IUserStore<AppIdentityUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<AppIdentityUser>(context.Get<IdentityContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AppIdentityUser>(manager)
            {
                RequireUniqueEmail = false,
                AllowOnlyAlphanumericUserNames = false
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<AppIdentityUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
