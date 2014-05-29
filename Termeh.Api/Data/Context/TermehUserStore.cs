using System.Data.Entity;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class TermehUserStore : UserStore<TermehUser, TermehRole, int, TermehUserLogin, TermehUserRole, TermehUserClaim>
    {
        public TermehUserStore(DbContext context)
            : base(context)
        {
        }
    }
}