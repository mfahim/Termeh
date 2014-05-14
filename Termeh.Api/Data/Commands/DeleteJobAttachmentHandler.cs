using System.Data.Entity;
using System.Linq;
using JobTrack.Api.Data.Models;
using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class DeleteJobAttachmentHandler : ICommandHandler<DeleteJobAttachmentCommand>
    {
        private readonly DbContext _context;

        public DeleteJobAttachmentHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(DeleteJobAttachmentCommand message)
        {
            var jb = _context.Set<JobAttachment>().Single(p => p.Id == message.Id);
            _context.Set<JobAttachment>().Remove(jb);

            _context.SaveChanges();
        }
    }
}