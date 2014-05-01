using System;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class AddJobCommand : ICommand
    {
        public decimal JobNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Quantity { get; set; }
        public int UserId { get; set; }
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
        public int UserId { get; set; }
    }

    public class DeleteJobCommand : ICommand
    {
        public int Id { get; set; }
    }
}