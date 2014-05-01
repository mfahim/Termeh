using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.JobStatus
{
    public class ShowJobStatusesQuery : IQuery<IList<JobStatusView>>
    {
    }

    public class ShowJobStatusesHandler : IQueryHandler<ShowJobStatusesQuery, IList<JobStatusView>>
    {
        private readonly DbContext _context;

        public ShowJobStatusesHandler(DbContext context)
        {
            _context = context;
        }

        public IList<JobStatusView> Handle(ShowJobStatusesQuery query)
        {
            var jb = _context.Set<Models.JobStatus>().ToList();
            return Mapper.Map<IList<JobStatusView>>(jb.ToList());
        }
    }
}