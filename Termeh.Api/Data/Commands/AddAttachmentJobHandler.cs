using System;
using System.Data.Entity;
using JobTrack.Api.Data.Models;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class AddAttachmentJobHandler : ICommandHandler<AddJobAttachmentCommand>
    {
        private readonly DbContext _context;

        public AddAttachmentJobHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(AddJobAttachmentCommand message)
        {
            _context.Set<Attachment>().Add(new Attachment()
                {
                    FileName = message.FileName,
                    FriendlyName = message.FriendlyName,
                    JobId = message.JobId,
                });

            _context.SaveChanges();
        }
    }
}