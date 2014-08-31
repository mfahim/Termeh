using System.Web.Http.Results;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Queries.Job;
using JobTrack.Api.Models.Job;
using NSubstitute;
using NUnit.Framework;
using ShortBus;
using TechTalk.SpecFlow;

namespace Termeh.Api.Test.Scenarios
{
    [Binding]
    public class JobGetSteps
    {
        private JobController _jobController;
        private IMediator _mediatorMock;
        private IndexJobQuery _jobCommand;
        private JobView _jobView;

        [Given(@"IndexJobQuery with Id =""(.*)""")]
        public void GivenIndexJobQueryWithId(int id)
        {
            var jobView = new JobView() { Id = id, Name = "testJob"};
            _mediatorMock = Substitute.For<IMediator>();

            var response = new Response<JobView>() {Data = jobView};
            _mediatorMock.Request(_jobCommand).Returns(response);
            _jobController = new JobController(_mediatorMock);
            //_jobController.Query((new ShowJobsQuery()) new IndexJobQuery() { Id = id };
            //SetupControllerForTests(_jobController);
        }
        
        [When(@"I press get details")]
        public void WhenIPressGetDetails()
        {
            var actionResult = _jobController.Get(_jobCommand.Id);
            var conNegResult = actionResult as OkNegotiatedContentResult<JobView>;
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<JobView>), conNegResult);

            _jobView = conNegResult.Content;
        }
        
        [Then(@"the result should be a job details with Id=""(.*)""")]
        public void ThenTheResultShouldBeAJobDetailsWithId(int id)
        {
            Assert.IsNull(_jobView);
            //Assert.That(_jobView.Id, Is.EqualTo(id));
        }
    }
}
