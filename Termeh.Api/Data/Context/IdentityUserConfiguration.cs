using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserConfiguration : EntityTypeConfiguration<TermehUser>
    {
        public IdentityUserConfiguration()
        {
            HasKey(user => user.Id);
            HasMany(usr => usr.Jobs).WithRequired().WillCascadeOnDelete(false);
            ToTable("TermehUsers", "User");
        }
    }
    public class IdentityUser1Configuration : EntityTypeConfiguration<TermehRole>
    {
        public IdentityUser1Configuration()
        {
            HasKey(user => user.Id);
            ToTable("Roles");
        }
    }
    public class IdentityUser2Configuration : EntityTypeConfiguration<TermehUserClaim>
    {
        public IdentityUser2Configuration()
        {
            HasKey(user => user.Id).;
            ToTable("UserClaims");
        }
    }
}