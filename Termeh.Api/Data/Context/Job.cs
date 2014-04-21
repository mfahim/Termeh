using System;

namespace JobTrack.Api.Data.Context
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> JobNumber { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public virtual JobStatus JobStatus { get; set; }
        public virtual User User { get; set; }
        public virtual int UserId { get; set; }
        public virtual int JobStatusId { get; set; }
    }
}