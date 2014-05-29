using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class JobTrackDbContext : IdentityDbContext<TermehUser, TermehRole, int, TermehUserLogin, TermehUserRole, TermehUserClaim>
    {
        public JobTrackDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<JobStatus> JobStatuses { get; set; }
        public IDbSet<JobAttachment> Attachments { get; set; }

        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new IdentityRoleConfiguration()); 
            modelBuilder.Configurations.Add(new IdentityUserConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserClaimConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public int Commit()
        {
            try
            {
                return SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new TermehContextException(ex);
            }
            catch (Exception ex)
            {
                throw new TermehContextException(ex);
            }
        }
    }
}