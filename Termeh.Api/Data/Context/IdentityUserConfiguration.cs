using System.Data.Entity.ModelConfiguration;
using JobTrack.Api.Data.Models;

namespace JobTrack.Api.Data.Context
{
    public class IdentityUserConfiguration : EntityTypeConfiguration<TermehUser>
    {
        public IdentityUserConfiguration()
        {
            HasKey(user => user.Id);
            HasMany(usr => usr.Jobs).WithRequired().HasForeignKey(fk => fk.AssignedToUserId).WillCascadeOnDelete(false);
            HasMany(usr => usr.Jobs).WithRequired().HasForeignKey(fk => fk.CreatedById).WillCascadeOnDelete(false);
            HasMany(usr => usr.TermUserRoles).WithRequired().HasForeignKey(fk => fk.UserId).WillCascadeOnDelete(false);
            ToTable("TermehUsers");
        }
    }
}