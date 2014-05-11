using System.Web.Http;
using JobTrack.Api.Data.Commands;
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

        [HttpPost]
        public IHttpActionResult Post(AddJobAttachmentCommand jobAttachViewModel)
        {
            jobAttachViewModel.FileName = jobAttachViewModel.FriendlyName;
            var response = Mediator.Send(jobAttachViewModel);

            if (response.HasException())
                return InternalServerError(BuildUserFriendlyMessage(response));

            //return Ok(jobViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "Job" }), jobAttachViewModel);
        }

    }
}