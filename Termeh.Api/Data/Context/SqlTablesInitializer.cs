using System.Data.Entity;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class SqlTablesInitializer : DropCreateDatabaseAlways<JobTrackDbContext>
    {
        protected override void Seed(JobTrackDbContext context)
        {
            InitJobStatuses(context);
            InitBuiltinUsers(context);

            context.SaveChanges();
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
        
        private static void InitBuiltinUsers(JobTrackDbContext context)
        {
            var users = context.DbSet<User>();
            users.Add(new User() {Id = 1, FullName = "Admin", Email = "admin@test.com"});
        }
    }
}