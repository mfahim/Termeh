using System.Collections.Generic;
using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.Job
{
    public class ShowJobsQuery : IQuery<IList<JobView>>
    {
    }
}