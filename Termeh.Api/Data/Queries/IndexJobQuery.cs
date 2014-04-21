using System;
using System.Collections.Generic;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries
{
    public class IndexJobQuery : IQuery<JobView>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ShowJobsQuery : IQuery<IList<JobView>>
    {
    }

    public class AddJobCommand : ICommand
    {
        public decimal JobNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Quantity { get; set; }
        public byte Status { get; set; }
        public int SalesRepId { get; set; }
    }

    public class EditJobCommand : ICommand
    {
        public int Id { get; set; }
        public decimal JobNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Quantity { get; set; }
        public int SalesRepId { get; set; }
    }

    public class DeleteJobCommand : ICommand
    {
        public int Id { get; set; }
    }
}