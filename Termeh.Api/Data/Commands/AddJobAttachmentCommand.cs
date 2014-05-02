using ShortBus;

namespace JobTrack.Api.Data.Commands
{
    public class AddJobAttachmentCommand : ICommand
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FriendlyName { get; set; }
        public int JobId { get; set; }
    }
}