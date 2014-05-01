using System.Collections.Generic;
using JobTrack.Api.Models.User;
using ShortBus;

namespace JobTrack.Api.Data.Queries.User
{
    public class ShowUsersQuery : IQuery<IList<UserView>>
    {
    }
}