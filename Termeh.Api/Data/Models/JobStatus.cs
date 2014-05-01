using System.Collections.Generic;

namespace JobTrack.Api.Data.Models
{
    public class JobStatus
    {
        public JobStatus()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}