using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JobTrack.Api.Models.User;
using ShortBus;

namespace JobTrack.Api.Data.Queries.User
{
    public class ShowUsersHandler : IQueryHandler<ShowUsersQuery, IList<UserView>>
    {
        private readonly DbContext _context;

        public ShowUsersHandler(DbContext context)
        {
            _context = context;
        }

        public IList<UserView> Handle(ShowUsersQuery query)
        {
            var users = _context.Set<Models.ApplicationUser>().ToList();
            return AutoMapper.Mapper.Map<IList<UserView>>(users);
        }
    }
}