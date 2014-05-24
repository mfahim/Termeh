using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JobTrack.Api.Data.Models
{
    public class GuidRole : IdentityRole<int, GuidUserRole>
    {
        public GuidRole()
        {
            Id = 0;
        }
        public GuidRole(string name) : this() { Name = name; }
    }
    public class GuidUserRole : IdentityUserRole<int> { }
    public class GuidUserClaim : IdentityUserClaim<int> { }

    public class GuidUserLogin : IdentityUserLogin<int>
    {

    }

    public class TermehUser : IdentityUser<int, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        public TermehUser(int userId)
        {
            Id = userId;
            Jobs = new HashSet<Job>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}