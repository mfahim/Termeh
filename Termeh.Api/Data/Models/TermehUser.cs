using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Models
{
    public class TermehUser : IdentityUser<int, TermehUserLogin, TermehUserRole, TermehUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<TermehUserRole> TermUserRoles { get; set; }
    }
}