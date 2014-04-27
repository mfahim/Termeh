using System.Web.Http;
using JobTrack.Api.Data.Commands;
using JobTrack.Api.Data.Queries;
using JobTrack.Api.Data.Queries.Job;
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

        [HttpPost]
        public IHttpActionResult Post(AddJobCommand jobViewModel)
        {
            var response = Mediator.Send(jobViewModel);

            if (response.HasException())
                return InternalServerError(BuildUserFriendlyMessage(response));

            //return Ok(jobViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "Job" }), jobViewModel);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, EditJobCommand jobViewModel)
        {
            var response = Mediator.Send(jobViewModel);

            if (response.HasException())
                return InternalServerError(BuildUserFriendlyMessage(response));

            return Ok(jobViewModel);
        }

        [HttpDelete]
        public IHttpActionResult DeleteResource(int id)
        {
            var response = Mediator.Send(new DeleteJobCommand() { Id = id });

            if (response.HasException())
                return InternalServerError(response.Exception);
            return Ok();
        }
    }
}