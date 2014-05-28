using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class GuidUserStore : UserStore<TermehUser, TermehRole, int, TermehUserLogin, TermehUserRole, TermehUserClaim>
    {
        public GuidUserStore(DbContext context)
            : base(context)
        {
        }
    }

    public class GuidRoleStore : RoleStore<TermehRole, int, TermehUserRole>
    {
        public GuidRoleStore(DbContext context)
            : base(context)
        {
        }
    }

    public class CustomUserManager : UserManager<TermehUser, int>
    {
        public CustomUserManager(GuidUserStore store)
            : base(store)
        {
        }
    }

    public class JobTrackDbContext : IdentityDbContext<TermehUser, TermehRole, int, TermehUserLogin, TermehUserRole, TermehUserClaim>
    {
        public JobTrackDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new ApplicationDbInitializer(this));
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

            //base.OnModelCreating(modelBuilder);
            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Entity<TermehRole>().HasKey<int>(r => r.Id).ToTable("TermehRoles"); 
            modelBuilder.Configurations.Add(new IdentityUserConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUser2Configuration());
            //modelBuilder.Entity<TermehUser>()
            //                 .Property(e => e.Id)
            //                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<TermehRole>()
            //    .Property(e => e.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<TermehUserClaim>()
            //     .Property(e => e.Id)
            //     .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
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