using System;
using System.Data.Entity;
using System.Linq;
using JobTrack.Api.Data.Models;
using JobTrack.Api.Data.Queries;
using JobTrack.Api.Data.Queries.Job;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class DeleteJobHandler : ICommandHandler<DeleteJobCommand>
    {
        private readonly DbContext _context;

        public DeleteJobHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(DeleteJobCommand message)
        {
            var jb = _context.Set<Job>().Single(p => p.Id == message.Id);
            _context.Set<Job>().Remove(jb);

            _context.SaveChanges();
        }
    }
}