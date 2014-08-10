using System.Web.Http.Routing;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Commands;
using ShortBus;
using TechTalk.SpecFlow;
using NSubstitute;
using NUnit.Framework;

namespace Termeh.Api.Test
{
    [Binding]
    public class JobCreationSteps
    {
        private JobController _jobController;
        private IMediator _mediatorMock;
        private AddJobCommand _jobCommand;

        [Given(@"AddJobCommand with Name =""(.*)"" and Number =""(.*)"" and description =""(.*)""")]
        public void GivenAddJobCommandWithNameAndNumberAndDescription(string name, int number, string description)
        {
            _jobCommand = new AddJobCommand() {Description = description, Name = name, JobNumber = number};
            _mediatorMock = Substitute.For<IMediator>();

            _mediatorMock.Send(_jobCommand);
            _jobController = new JobController(_mediatorMock);
            var mockUrlHelper = Substitute.For<UrlHelper>();

            string apiUrl = "http://api/job/";
            mockUrlHelper.Link(Arg.Any<string>(), Arg.Any<object>()).Returns(apiUrl);
            _jobController.Url = mockUrlHelper;
        }
        
        [When(@"I press newJob")]
        public void WhenIPressNewJob()
        {
            _jobController.Post(_jobCommand);
        }

        [Then(@"the result should be a job with Name=""(.*)""")]
        public void TheResultShouldBeAJob(string jobName)
        {
            Assert.That(jobName, Is.EqualTo(_jobCommand.JobNumber));
        }
    }
}
