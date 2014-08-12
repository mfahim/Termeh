using System;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Queries.Job;
using JobTrack.Api.Models.Job;
using NSubstitute;
using NUnit.Framework;
using Newtonsoft.Json;
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
        private int _id;
        private JobView _jobView;

        [Given(@"IndexJobQuery with Id =""(.*)""")]
        public void GivenIndexJobQueryWithId(int id)
        {
            _jobCommand = new IndexJobQuery() { Id = id};
            var jobView = new JobView() { Id = id, Name = "testJob"};
            _mediatorMock = Substitute.For<IMediator>();

            _mediatorMock.Request(_jobCommand).Returns(new Response<JobView>(){ Data = jobView});
            _jobController = new JobController(_mediatorMock);
            SetupControllerForTests(_jobController);
            _id = id;
        }
        
        [When(@"I press get details")]
        public void WhenIPressGetDetails()
        {
            var content = _jobController.Get(_id).ExecuteAsync(CancellationToken.None).Result.Content.ReadAsStringAsync().Result;
            var t = JsonConvert.DeserializeObject<JobView>(content);

        }
        
        [Then(@"the result should be a job details with Id=""(.*)""")]
        public void ThenTheResultShouldBeAJobDetailsWithId(int id)
        {
            Assert.That(_id, Is.EqualTo(id));
        }

        private void SetupControllerForTests(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/job");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "job" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }
    }
}
