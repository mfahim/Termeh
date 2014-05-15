using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.Job
{
    public class ShowJobAttachmentsHandler : IQueryHandler<ShowJobAttachmentsQuery, IList<JobAttachmentView>>
    {
        private readonly DbContext _context;

        public ShowJobAttachmentsHandler(DbContext context)
        {
            _context = context;
        }

        public IList<JobAttachmentView> Handle(ShowJobAttachmentsQuery query)
        {
            var jb = _context.Set<Models.JobAttachment>().Where(j => j.JobId == query.JobId);
            return Mapper.Map<IList<JobAttachmentView>>(jb);
        }
    }
}