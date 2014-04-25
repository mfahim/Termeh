using System.Collections.Generic;

namespace JobTrack.Api.Data.Context
{
    public class User
    {
        public User()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string IdentityToken { get; set; }
        public string FullName { get; set; }
        public string RepCode { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}