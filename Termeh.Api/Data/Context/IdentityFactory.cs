using System;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity;

namespace JobTrack.Api.Data.Context
{
    public class IdentityFactory
    {
        public static UserManager<TermehUser, int> CreateUserManager(JobTrackDbContext context)
        {
            var manager = new UserManager<TermehUser, int>(new TermehUserStore(context));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<TermehUser, int>(manager)
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
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<TermehUser, int>
                {
                    MessageFormat = "Your security code is: {0}"
                });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<TermehUser, int>
                {
                    Subject = "SecurityCode",
                    BodyFormat = "Your security code is {0}"
                });
            return manager;
        }

        public static RoleManager<TermehRole, int> CreateRoleManager(JobTrackDbContext context)
        {
            return new RoleManager<TermehRole, int>(new TermehRoleStore(context));
        }
    }
}