using System.Data.Entity;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class SqlTablesInitializer : DropCreateDatabaseAlways<JobTrackDbContext>
    {
        protected override void Seed(JobTrackDbContext context)
        {
            CreateUsers(context);
            InitJobStatuses(context);

            context.SaveChanges();
        }

        private static void CreateUsers(JobTrackDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("Member"))
            {
                roleManager.Create(new IdentityRole("Member"));
            }

            var user = new ApplicationUser();
            user.FirstName = "Admin";
            user.LastName = "Last Name";
            user.Email = "admin@hotmail.com";
            user.UserName = "admin@hotmail.com";

            var userResult = userManager.Create(user, "Termeh");

            if (userResult.Succeeded)
            {
                //var user = userManager.FindByName("admin@marlabs.com");
                //userManager.AddToRole<ApplicationUser>(user.Id, "Admin");
            }
            
        }
        private static void InitJobStatuses(JobTrackDbContext context)
        {
            var jobStatuses = context.DbSet<JobStatus>();
            jobStatuses.Add(new JobStatus() { Id = 1, Name = "New" });
            jobStatuses.Add(new JobStatus() { Id = 2, Name = "ArtOnProof" });
            jobStatuses.Add(new JobStatus() { Id = 3, Name = "Binding" });
            jobStatuses.Add(new JobStatus() { Id = 4, Name = "Dispatched" });
            jobStatuses.Add(new JobStatus() { Id = 5, Name = "Finished" });
            jobStatuses.Add(new JobStatus() { Id = 6, Name = "Cancelled" });
        }        
    }
}