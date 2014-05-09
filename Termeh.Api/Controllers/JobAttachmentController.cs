using System.Web.Http;
using JobTrack.Api.Data.Queries.Job;
using ShortBus;

namespace JobTrack.Api.Controllers
{
    public class JobAttachmentController : JobTrackBaseController
    {
        public JobAttachmentController(IMediator mediator) :
            base(mediator)
        {
        }

        public IHttpActionResult Get(int jobId)
        {
            var model = Mediator.Request(new ShowJobAttachmentsQuery(){ JobId = jobId});
            return Ok(model.Data);
        }
    }
}