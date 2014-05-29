using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity;

namespace JobTrack.Api.Data.Context
{
    public class TermehUserManager : UserManager<TermehUser, int>
    {
        public TermehUserManager(TermehUserStore store)
            : base(store)
        {
        }
    }
}