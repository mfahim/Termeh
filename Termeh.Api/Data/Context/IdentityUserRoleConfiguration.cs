using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<GuidUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            ToTable("UserRoles", "User");
            HasKey(role => new { role.RoleId, role.UserId });
            //HasRequired(role => role.User).WithMany().HasForeignKey(role => role.UserId);
        }
    }
}