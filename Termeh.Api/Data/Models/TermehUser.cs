using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JobTrack.Api.Data.Models
{
    public class TermehRole : IdentityRole<int, TermehUserRole>
    {
        public TermehRole()
        {}
        public TermehRole(string name) : this() { Name = name; }
    }
    public class TermehUserRole : IdentityUserRole<int> { }
    public class TermehUserClaim : IdentityUserClaim<int> { }
    public class TermehUserLogin : IdentityUserLogin<int> { }

    public class TermehUser : IdentityUser<int, TermehUserLogin, TermehUserRole, TermehUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<TermehUserRole> TermUserRoles { get; set; }
    }
}