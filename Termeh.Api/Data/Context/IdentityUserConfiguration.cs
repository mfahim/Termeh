using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserConfiguration : EntityTypeConfiguration<TermehUser>
    {
        public IdentityUserConfiguration()
        {
            HasKey(user => user.Id);
            ToTable("TermehUsers", "User");
        }
    }
    public class IdentityUser1Configuration : EntityTypeConfiguration<GuidRole>
    {
        public IdentityUser1Configuration()
        {
            HasKey(user => user.Id);
            ToTable("Roles", "User");
        }
    }
    public class IdentityUser2Configuration : EntityTypeConfiguration<GuidUserClaim>
    {
        public IdentityUser2Configuration()
        {
            HasKey(user => user.Id);
            ToTable("UserClaims", "User");
        }
    }
}