using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<GuidUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            ToTable("UserLogins", "User");
            HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });
            Property(l => l.UserId).HasColumnType("int");
        }
    }
}