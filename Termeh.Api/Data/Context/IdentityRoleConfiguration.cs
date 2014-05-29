using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityRoleConfiguration : EntityTypeConfiguration<TermehRole>
    {
        public IdentityRoleConfiguration()
        {
            HasKey(user => user.Id);
            ToTable("TermehRoles");
        }
    }
}