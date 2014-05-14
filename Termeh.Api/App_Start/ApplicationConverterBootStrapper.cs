using JobTrack.Api.Data.Models;
using JobTrack.Api.Models.Job;
using JobTrack.Api.Models.User;

namespace JobTrack.Api
{
    public static class ApplicationConverterBootStrapper
    {
        public static void Start()
        {
            AutoMapper.Mapper.CreateMap<Job, JobView>()
                .ForMember(p => p.Status, s => s.MapFrom(o => o.JobStatus.Id))
                .ForMember(p => p.AssignedTo, s => s.MapFrom(o => o.ApplicationUser.FirstName));
            AutoMapper.Mapper.CreateMap<JobStatus, JobStatusView>();
            AutoMapper.Mapper.CreateMap<ApplicationUser, UserView>();
            AutoMapper.Mapper.CreateMap<JobAttachment, JobAttachmentView>();
        }
    }
}