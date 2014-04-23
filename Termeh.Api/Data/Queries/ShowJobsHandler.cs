using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using JobTrack.Api.Models.Job;
using ShortBus;
using Job = JobTrack.Api.Data.Context.Job;

namespace JobTrack.Api.Data.Queries
{
    public class IndexJobsHandler : IQueryHandler<IndexJobQuery, JobView>
    {
        private readonly DbContext _context;

        public IndexJobsHandler(DbContext context)
        {
            _context = context;
        }

        public JobView Handle(IndexJobQuery query)
        {
            var jb = _context.Set<Job>().Include(a => a.JobStatus).SingleOrDefault(j => j.Id == query.Id);
            return Mapper.Map<JobView>(jb);
        }
    }

    public class ShowJobsHandler : IQueryHandler<ShowJobsQuery, IList<JobView>>
    {
        private readonly DbContext _context;

        public ShowJobsHandler(DbContext context)
        {
            _context = context;
        }

        public IList<JobView> Handle(ShowJobsQuery query)
        {
            var jobs = _context.Set<Job>().Include(a => a.JobStatus);
            return Mapper.Map<IList<JobView>>(jobs.ToList());
        }
    }

    public class AddJobHandler : ICommandHandler<AddJobCommand>
    {
        private readonly DbContext _context;

        public AddJobHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(AddJobCommand message)
        {
            _context.Set<Job>().Add(new Job()
            {
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(10),
                JobNumber = message.JobNumber,
                Name = message.Name,
                Quantity = message.Quantity,
                Description = message.Description,
                JobStatusId = 1,
                UserId = 1,
                CreatedBy = 1
            });

            _context.SaveChanges();
        }
    }

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
            jb.DueDate = DateTime.Now.AddDays(2);
            jb.CreatedDate = DateTime.Now;
            //jb.CreatedBy = message.CreatedById;
            jb.Description = message.Description;
            //jb.JobStatus = (JobStatus)Enum.Parse(typeof(JobStatus), message.Status.ToString());
            jb.Quantity = message.Quantity;
            jb.Name = message.Name;
            _context.SaveChanges();

            _logger.Handle(new LogCommand("Successfully updated"));
        }
    }

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

    public class LogCommand
    {
        public string LogMessage { get; set; }
        public DateTime Time { get; set; }

        public LogCommand(string message)
        {
            LogMessage = message;
            Time = DateTime.Now;
        }
    }
}