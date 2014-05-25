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
            InitApplicationUsers(context);
            InitJobStatuses(context);

            context.SaveChanges();
        }

        private static void InitApplicationUsers(JobTrackDbContext context)
        {
            var userManager = new UserManager<TermehUser, int>(new GuidUserStore(context));
            userManager.UserValidator = new UserValidator<TermehUser, int>(userManager)
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

            var user = new TermehUser(1)
                {FirstName = "Admin", LastName = "Termeh", Email = "admin@hotmail.com"};

            var userResult = userManager.Create(user, "Termeh");

            if (userResult.Succeeded)
            {
                //var user = userManager.FindByName("admin@marlabs.com");
                //userManager.AddToRole<>(user.Id, "Admin");
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