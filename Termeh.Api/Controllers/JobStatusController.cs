using System.Web.Http;
using JobTrack.Api.Data.Queries.JobStatus;
using ShortBus;

namespace JobTrack.Api.Controllers
{
    public class JobStatusController : JobTrackBaseController
    {
        public JobStatusController(IMediator mediator) :
            base(mediator)
        {
        }

        public IHttpActionResult Get()
        {
            var model = Mediator.Request(new ShowJobStatusesQuery());
            return Ok(model.Data);
        }
    }
}