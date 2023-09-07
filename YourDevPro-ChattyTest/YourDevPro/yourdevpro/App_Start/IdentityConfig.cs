using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using DevProApp.Areas.Administration.Models;

namespace DevProApp.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string cFirstName = "Admin";
            const string cLastname = "Example";
            const string cAddress = "123 AdminUser St.";
            const string cCity = "National Park";
            const string cState = "NJ";
            const string cCountry = "USA";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser {
                    UserName = name,
                    Email = name,
                    FirstName = cFirstName,
                    Lastname = cLastname,
                    Address = cAddress,
                    City = cCity,
                    State = cState,
                    Country = cCountry
                };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }


            //pre-load Superuser role
            const string name2 = "superuser@example.com";
            const string password2 = "Superuser@123456";
            const string FirstName2 = "SuperUser";
            const string Lastname2 = "Example";
            const string Address2 = "123 SuperUser St.";
            const string City2 = "National Park";
            const string State2 = "NJ";
            const string Country2 = "USA";
            const string roleName2 = "Superuser";

            //Create Role Member if it does not exist
            var role2 = roleManager.FindByName(roleName2);
            if (role2 == null)
            {
                role2 = new IdentityRole(roleName2);
                var roleresult = roleManager.Create(role2);
            }

            var user2 = userManager.FindByName(name2);
            if (user2 == null)
            {
                user2 = new ApplicationUser {
                    UserName = name2,
                    Email = name2,
                    FirstName = FirstName2,
                    Lastname = Lastname2,
                    Address = Address2,
                    City = City2,
                    State = State2,
                    Country = Country2
                };
                var result = userManager.Create(user2, password2);
                result = userManager.SetLockoutEnabled(user2.Id, false);
            }

            // Add user Member to Role Member if not already added
            var rolesForUser2 = userManager.GetRoles(user2.Id);
            if (!rolesForUser2.Contains(role2.Name))
            {
                var result = userManager.AddToRole(user2.Id, role2.Name);
            }

            //pre-load User role
            const string name3 = "user@example.com";
            const string password3 = "User@123456";
            const string FirstName3 = "User";
            const string Lastname3 = "Example";
            const string Address3 = "123 User St.";
            const string City3 = "National Park";
            const string State3 = "NJ";
            const string Country3 = "USA";
            const string roleName3 = "User";

            //Create Role Member if it does not exist
            var role3 = roleManager.FindByName(roleName3);
            if (role3 == null)
            {
                role3 = new IdentityRole(roleName3);
                var roleresult = roleManager.Create(role3);
            }

            var user3 = userManager.FindByName(name3);
            if (user3 == null)
            {
                user3 = new ApplicationUser {
                    UserName = name3,
                    Email = name3,
                    FirstName = FirstName3,
                    Lastname = Lastname3,
                    Address = Address3,
                    City = City3,
                    State = State3,
                    Country = Country3
                };
                var result = userManager.Create(user3, password3);
                result = userManager.SetLockoutEnabled(user3.Id, false);
            }

            // Add user Member to Role Member if not already added
            var rolesForUser3 = userManager.GetRoles(user3.Id);
            if (!rolesForUser3.Contains(role3.Name))
            {
                var result = userManager.AddToRole(user3.Id, role3.Name);
            }
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}