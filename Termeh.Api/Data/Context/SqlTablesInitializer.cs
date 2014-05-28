using System.Data.Entity;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<JobTrackDbContext>
    {
        public ApplicationDbInitializer(JobTrackDbContext context)
        {
            base.Seed(context);

            InitApplicationUsers(context);
            InitJobStatuses(context);
            context.SaveChanges();
        }

        private static void InitApplicationUsers(JobTrackDbContext context)
        {
            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";
            var applicationRoleManager = IdentityFactory.CreateRoleManager(context);
            var applicationUserManager = IdentityFactory.CreateUserManager(context);

            //Create Role Admin if it does not exist
            var role = applicationRoleManager.FindByName(roleName);
            if (role == null)
            {
                role = new TermehRole() { Name = roleName };
                applicationRoleManager.Create(role);
            }

            var user = applicationUserManager.FindByName(name);
            if (user == null)
            {
                user = new TermehUser() { UserName = name, Email = name, FirstName = "Admin", LastName = "Termeh"};
                applicationUserManager.Create(user, password);
                applicationUserManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = applicationUserManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                applicationUserManager.AddToRole(user.Id, role.Name);
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