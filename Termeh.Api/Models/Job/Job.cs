using System;
using System.Collections.Generic;

namespace JobTrack.Api.Models.Job
{
    public class Job
    {
        public int Id { get; set; }
        public decimal JobNumber { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; } 
        public JobUser SalesRep { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public JobUser CreatedBy { get; set; }
        public decimal Quantity { get; set; }
        public IList<string> Attachments { get; set; }
        public string Description { get; set; }
    }
}