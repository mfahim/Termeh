using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class JobTrackDbContext : IdentityDbContext<ApplicationUser>
    {
        public JobTrackDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<JobStatus> JobStatuses { get; set; }
        public IDbSet<Attachment> Attachments { get; set; }

        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Configurations.Add(new IdentityUserConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
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