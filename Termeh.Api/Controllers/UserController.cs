using System.Web.Http;
using JobTrack.Api.Data.Queries.User;
using ShortBus;

namespace JobTrack.Api.Controllers
{
    public class UserController : JobTrackBaseController
    {
        public UserController(IMediator mediator) :
            base(mediator)
        {
        }

        public IHttpActionResult Get()
        {
            var model = Mediator.Request(new ShowUsersQuery());
            return Ok(model.Data);
        }
    }
}