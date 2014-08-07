using System;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Commands;
using ShortBus;
using TechTalk.SpecFlow;

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
            _mediatorMock = NSubstitute.Substitute.For<IMediator>();

            _mediatorMock.Send(_jobCommand);
            _jobController = new JobController(_mediatorMock);
        }
        
        [When(@"I press newJob")]
        public void WhenIPressNewJob()
        {
            _jobController.Post(_jobCommand);
        }

        //[Then(@"the result should be a job")]
        //public void TheResultShouldBeAJob()
        //{

        //}
    }
}
