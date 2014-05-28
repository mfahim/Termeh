using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<TermehUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            ToTable("TermehUserRoles");
            HasKey(role => new { role.RoleId, role.UserId });
        }
    }
}