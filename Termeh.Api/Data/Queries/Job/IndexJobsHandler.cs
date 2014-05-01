using System.Data.Entity;
using System.Linq;
using AutoMapper;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.Job
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
            var jb = _context.Set<Models.Job>().Include(a => a.JobStatus).SingleOrDefault(j => j.Id == query.Id);
            return Mapper.Map<JobView>(jb);
        }
    }
}