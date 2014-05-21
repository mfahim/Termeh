using System;
using System.Data.Entity;
using System.Linq;
using JobTrack.Api.Data.Models;
using JobTrack.Api.Data.Queries;
using JobTrack.Api.Data.Queries.Helpers;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class EditJobHandler : ICommandHandler<EditJobCommand>
    {
        private readonly DbContext _context;
        private readonly ICommandHandler<LogCommand> _logger;

        public EditJobHandler(DbContext context, ICommandHandler<LogCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Handle(EditJobCommand message)
        {
            var jb = _context.Set<Job>().Single(p => p.Id == message.Id);
            jb.JobNumber = message.JobNumber;
            jb.DueDate = message.DueDate;
            jb.CreatedDate = DateTime.Now;
            jb.Description = message.Description;
            jb.Quantity = message.Quantity;
            jb.Name = message.Name;
            jb.AssignedToUserId = message.UserId;
            _context.SaveChanges();

            _logger.Handle(new LogCommand("Successfully updated"));
        }
    }
}