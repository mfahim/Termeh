using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.Job
{
    public class ShowJobsHandler : IQueryHandler<ShowJobsQuery, IList<JobView>>
    {
        private readonly DbContext _context;

        public ShowJobsHandler(DbContext context)
        {
            _context = context;
        }

        public IList<JobView> Handle(ShowJobsQuery query)
        {
            var jobs = _context.Set<Models.Job>().Include(a => a.JobStatus).Include(a => a.ApplicationUser);
            return Mapper.Map<IList<JobView>>(jobs.ToList());
        }
    }
}