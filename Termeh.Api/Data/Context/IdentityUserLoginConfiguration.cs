using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });
            //HasRequired(login => login.UserId).WithMany().HasForeignKey(login => login.UserId);
        }
    }
}