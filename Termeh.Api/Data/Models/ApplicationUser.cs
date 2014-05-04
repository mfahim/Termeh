using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JobTrack.Api.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Jobs = new HashSet<Job>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}