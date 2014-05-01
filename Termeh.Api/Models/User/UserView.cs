namespace JobTrack.Api.Models.User
{
    public class UserView
    {
        public int Id { get; set; }
        public string IdentityToken { get; set; }
        public string FullName { get; set; }
        public string RepCode { get; set; }
        public string Email { get; set; }
    }
}