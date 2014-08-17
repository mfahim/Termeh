using System;
using System.Collections.Generic;
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
    public class JobGetAllSteps
    {
        private JobController _jobController;
        private IMediator _mediatorMock;
        private ShowJobsQuery _jobCommand;
        private IList<JobView> _jobViews;

        [Given(@"ShowJobsQuery")]
        public void GivenShowJobsQuery()
        {
            _jobCommand = new ShowJobsQuery();
            var jobViews = new List<JobView>() { new JobView(){ Id = 1, Name = "test1"}};
            _mediatorMock = Substitute.For<IMediator>();

            var response = new Response<IList<JobView>>() { Data = jobViews };
            _mediatorMock.Request(_jobCommand).Returns(response);
            _jobController = new JobController(_mediatorMock);
        }
        
        [When(@"I press get all jobs")]
        public void WhenIPressGetAllJobs()
        {
            var actionResult = _jobController.Get(_jobCommand);
            var conNegResult = actionResult as OkNegotiatedContentResult<IList<JobView>>;
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<IList<JobView>>), conNegResult);

            _jobViews = conNegResult.Content;
        }
        
        [Then(@"the result should be list of jobs")]
        public void ThenTheResultShouldBeListOfJobs()
        {
            Assert.That(_jobViews.Count, Is.EqualTo(1));
        }
    }
}
