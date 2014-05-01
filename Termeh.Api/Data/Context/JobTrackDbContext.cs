using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class JobTrackDbContext : DbContext
    {
        public JobTrackDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<JobStatus> JobStatuses { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Attachment> Attachments { get; set; }

        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
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

        public void CreateDataBase()
        {
            if (Database.Exists())
                Database.Delete();

            Database.SetInitializer(new SqlTablesInitializer());
            Database.Initialize(true);
        }
    }
}