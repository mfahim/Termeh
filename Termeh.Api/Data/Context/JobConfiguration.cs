using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            HasKey(role => new { role.Id });
            HasRequired(role => role.AssignedToUser).WithMany(p => p.Jobs).HasForeignKey(fk => fk.AssignedToUserKey).WillCascadeOnDelete(false);
            HasRequired(role => role.CreatedBy).WithMany(p => p.Jobs).HasForeignKey(role => role.CreatedByUserKey).WillCascadeOnDelete(false);
        }
    }
}