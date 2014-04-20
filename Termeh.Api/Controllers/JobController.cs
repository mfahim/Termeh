using System.Web.Http;
using JobTrack.Api.Data.Queries;
using ShortBus;

namespace JobTrack.Api.Controllers
{
    public class JobController : JobTrackBaseController
    {
        public JobController(IMediator mediator) :
            base(mediator)
        {
        }

        public IHttpActionResult Get()
        {
            var model = Mediator.Request(new ShowJobsQuery());
            return Ok(model.Data);
        }

        public IHttpActionResult Get(int id)
        {
            var model = Mediator.Request(new IndexJobQuery() { Id = id });

            return Ok(model.Data);
        }

        public IHttpActionResult Post(EditJobCommand jobViewModel)
        {
            var response = Mediator.Send(jobViewModel);

            if (response.HasException())
                return InternalServerError(BuildUserFriendlyMessage(response));

            return Created(Url.Link("DefaultApi", new { controller = "Job" }), jobViewModel);
        }

        public IHttpActionResult Put(int id, EditJobCommand jobViewModel)
        {
            var response = Mediator.Send(jobViewModel);

            if (response.HasException())
                return InternalServerError(BuildUserFriendlyMessage(response));

            return Ok(jobViewModel);
        }

        public IHttpActionResult DeleteResource(int id)
        {
            var response = Mediator.Send(new DeleteJobCommand() { Id = id });

            if (response.HasException())
                return InternalServerError(response.Exception);
            return Ok();
        }
    }
}