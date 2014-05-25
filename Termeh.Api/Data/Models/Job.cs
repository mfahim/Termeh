using System;
using System.Collections.Generic;

namespace JobTrack.Api.Data.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> JobNumber { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public virtual JobStatus JobStatus { get; set; }
        public virtual TermehUser AssignedToUser { get; set; }
        public virtual TermehUser CreatedBy { get; set; }
        public virtual int CreatedByUserKey { get; set; }
        public virtual int AssignedToUserKey { get; set; }
        public virtual int JobStatusId { get; set; }
        public virtual IList<JobAttachment> Attachments { get; set; }
    }
}