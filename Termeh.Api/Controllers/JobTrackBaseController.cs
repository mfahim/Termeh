using System;
using System.Linq;
using System.Web.Http;
using ShortBus;

namespace JobTrack.Api.Controllers
{
    public class JobTrackBaseController : ApiController
    {
        protected IMediator Mediator { get; private set; }

        public JobTrackBaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected Exception BuildUserFriendlyMessage(Response response)
        {
            if (!response.HasException())
                return null;
            var exp = response.Exception as AggregateException;
            if (exp.InnerExceptions.Count == 1)
                return exp.InnerExceptions.First();

            return exp.InnerExceptions.First();
        }
    }
}