using JobTrack.Api.Data.Context;
using JobTrack.Api.Models.Job;

namespace JobTrack.Api
{
    public static class ApplicationConverterBootStrapper
    {
        public static void Start()
        {
            AutoMapper.Mapper.CreateMap<Job, JobView>().ForMember(p => p.Status, s => s.MapFrom(o => o.JobStatus.Id));
        }
    }
}