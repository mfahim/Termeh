using JobTrack.Api.Data.Context;
using JobTrack.Api.Models.Job;
using JobTrack.Api.Models.User;

namespace JobTrack.Api
{
    public static class ApplicationConverterBootStrapper
    {
        public static void Start()
        {
            AutoMapper.Mapper.CreateMap<Job, JobView>().ForMember(p => p.Status, s => s.MapFrom(o => o.JobStatus.Id));
            AutoMapper.Mapper.CreateMap<JobStatus, JobStatusView>();
            AutoMapper.Mapper.CreateMap<User, UserView>();
        }
    }
}