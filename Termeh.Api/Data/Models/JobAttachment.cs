namespace JobTrack.Api.Data.Models
{
    public class JobAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FriendlyName { get; set; }
        public virtual Job Job { get; set; }
        public int JobId { get; set; }
    }
}