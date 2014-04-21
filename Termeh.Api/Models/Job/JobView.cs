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
        public int SalesRep { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CreatedBy { get; set; }
        public decimal Quantity { get; set; }
        public IList<string> Attachments { get; set; }
        public string Description { get; set; }
    }
}