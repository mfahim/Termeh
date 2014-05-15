using JobTrack.Api.Models.Job;
using ShortBus;

namespace JobTrack.Api.Data.Queries.Job
{
    public class IndexJobQuery : IQuery<JobView>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}