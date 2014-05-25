using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class GuidUserStore : UserStore<TermehUser, GuidRole, int, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        public GuidUserStore(DbContext context)
            : base(context)
        {
        }
    }

    public class GuidRoleStore : RoleStore<GuidRole, int, GuidUserRole>
    {
        public GuidRoleStore(DbContext context)
            : base(context)
        {
        }
    }
    
    public class JobTrackDbContext : IdentityDbContext<TermehUser, GuidRole, int, GuidUserLogin, GuidUserRole, GuidUserClaim>
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

            base.OnModelCreating(modelBuilder);
            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Entity<GuidRole>().HasKey<int>(r => r.Id).ToTable("TermehRoles"); 
            modelBuilder.Configurations.Add(new IdentityUserConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUser2Configuration());
            modelBuilder.Configurations.Add(new JobConfiguration());
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