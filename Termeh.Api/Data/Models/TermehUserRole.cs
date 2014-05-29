using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Models
{
    public class TermehUserRole : IdentityUserRole<int> { }
    public class TermehUserClaim : IdentityUserClaim<int> { }
    public class TermehUserLogin : IdentityUserLogin<int> { }
}