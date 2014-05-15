using System;
using System.Collections.Generic;

namespace JobTrack.Api.Models.Job
{
    public class JobView
    {
        public int Id { get; set; }
        public decimal JobNumber { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CreatedBy { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public int UserId { get; set; }
        public IList<JobAttachmentView> AttchmentViews { get; set; }
    }
}