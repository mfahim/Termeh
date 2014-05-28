using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<TermehUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            ToTable("TermehUserLogins");
            HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });
            //Property(l => l.UserId).HasColumnType("int");
        }
    }
}