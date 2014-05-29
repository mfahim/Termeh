using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Models
{
    public class TermehRole : IdentityRole<int, TermehUserRole>
    {
        public TermehRole()
        {
        }

        public TermehRole(string name) : this()
        {
            Name = name;
        }
    }
}