using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserConfiguration : EntityTypeConfiguration<IdentityUser>
    {
        public IdentityUserConfiguration()
        {
            HasKey(user => new { user.Id });
            //HasRequired(login => login.).WithMany().HasForeignKey(login => login.UserId);
        }
    }
}