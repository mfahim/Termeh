using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserClaimConfiguration : EntityTypeConfiguration<TermehUserClaim>
    {
        public IdentityUserClaimConfiguration()
        {
            HasKey(user => user.Id);
            ToTable("TermehUserClaims");
        }
    }
}