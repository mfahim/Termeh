using AutoMapper;
using JobTrack.Api.Data.Context;
using JobTrack.Api.Models.Job;

namespace JobTrack.Api.Data.Queries
{
    public static class ApplicationConverterBootStrapper
    {
        public static void Start()
        {
            Mapper.CreateMap<Job, JobView>()
                .ForMember(p => p.Status, s => s.MapFrom( o => o.JobStatusId));
        }
    }
}