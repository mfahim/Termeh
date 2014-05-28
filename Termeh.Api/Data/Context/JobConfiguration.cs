using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            HasKey(role => new { role.Id });
            HasRequired(role => role.AssignedToUser).WithMany().WillCascadeOnDelete(false);
            HasRequired(role => role.CreatedBy).WithMany().WillCascadeOnDelete(false);
        }
    }
}