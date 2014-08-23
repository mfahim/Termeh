using System;
using System.Web.Http.Results;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Queries.Job;
using JobTrack.Api.Models.Job;
using NSubstitute;
using NUnit.Framework;
using ShortBus;
using TechTalk.SpecFlow;

namespace Termeh.Api.Test
{
    [Binding]
    public class JobGetStepsWhenNull
    {
        private JobController _jobController;
        private IMediator _mediatorMock;
        private IndexJobQuery _jobCommand;
        private JobView _jobView;

        [Given(@"IndexJobQuery with Id =""(.*)"" And jobId is not available")]
        public void GivenIndexJobQueryWithIdAndJobIdIsNotAvailable(int id)
        {
            _jobCommand = new IndexJobQuery() { Id = id };
            _mediatorMock = Substitute.For<IMediator>();

            var response = new Response<JobView>() { Data = null };
            _mediatorMock.Request(_jobCommand).Returns(response);
            _jobController = new JobController(_mediatorMock);
        }

        [When(@"I press get unavailable")]
        public void IPressGetUnavailable()
        {
            //var actionResult = _jobController.Get(_jobCommand);
            //var conNegResult = actionResult as OkNegotiatedContentResult<JobView>;
            //Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<JobView>), conNegResult);

            //_jobView = conNegResult.Content;
        }

        [Then(@"the result should be a null")]
        public void ThenTheResultShouldBeANull()
        {
            Assert.Null(_jobView);
        }
    }
}
