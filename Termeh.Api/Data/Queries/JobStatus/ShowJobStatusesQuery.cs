using System.Collections.Generic;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.JobStatus
{
    public class ShowJobStatusesQuery : IQuery<IList<JobStatusView>>
    {
    }
}