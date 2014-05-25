using System;
using System.Data.Entity;
using JobTrack.Api.Data.Models;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class AddJobHandler : ICommandHandler<AddJobCommand>
    {
        private readonly DbContext _context;

        public AddJobHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(AddJobCommand message)
        {
            var username = _context.Set<TermehUser>().FirstAsync().Result.Id;
            _context.Set<Job>().Add(new Job()
                {
                    CreatedDate = DateTime.Now,
                    DueDate = message.DueDate,
                    JobNumber = message.JobNumber,
                    Name = message.Name,
                    Quantity = message.Quantity,
                    Description = message.Description,
                    JobStatusId = 1,
                    AssignedToUserKey = username,
                    // todo: coming from auth services
                    CreatedByUserKey = username
                });

            _context.SaveChanges();
        }
    }
}