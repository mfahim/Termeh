using System.Data.Entity;
using JobTrack.Api.Data.Models;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class AddJobAttachmentHandler : ICommandHandler<AddJobAttachmentCommand>
    {
        private readonly DbContext _context;

        public AddJobAttachmentHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(AddJobAttachmentCommand message)
        {
            _context.Set<JobAttachment>().Add(new JobAttachment()
                {
                    FileName = message.FileName,
                    FriendlyName = message.FriendlyName,
                    JobId = message.JobId,
                    Id = message.Id
                });

            _context.SaveChanges();
        }
    }
}