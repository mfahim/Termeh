using System.Data.Entity;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobTrack.Api.Data.Context
{
    public class TermehRoleStore : RoleStore<TermehRole, int, TermehUserRole>
    {
        public TermehRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}