using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Commands;
using JobTrack.Api.Data.Queries.Job;
using NSubstitute;
using NUnit.Framework;
using ShortBus;

namespace Termeh.Api.Test.UnitTests.Job
{
    [TestFixture]
    public class WhenCreatingAJob
    {
        [Test]
        public void ShouldReturnHttpStatusOk()
        {
            var jobCommand = new AddJobCommand() { Description = "zz", Name = "qq", JobNumber = 104 };
            var mediatorMock = Substitute.For<IMediator>();

            mediatorMock.Send(jobCommand);
            string apiUrl = "http://api/job/";
            var mockUrlHelper = Substitute.For<UrlHelper>();
            mockUrlHelper.Link(Arg.Any<string>(), Arg.Any<object>()).Returns(apiUrl);

            var jobCtrl = new JobController(mediatorMock);
            SetupControllerForTests(jobCtrl);
            jobCtrl.Url = mockUrlHelper;

            var result = jobCtrl.Post(jobCommand);

            var task = result.ExecuteAsync(CancellationToken.None);
            Assert.That(HttpStatusCode.Created, Is.EqualTo(task.Result.StatusCode));
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

        [Test]
        public void Should_CallShowJobsQuery_With_GetAllJobs()
        {
            var mediatorMock = Substitute.For<IMediator>();

            var jobCtrl = Substitute.For<JobController>(mediatorMock);

            jobCtrl.Get();
            jobCtrl.Received().Query(Arg.Any<ShowJobsQuery>());
        }

        [Test]
        public void Should_CallShowJobsQuery_With_GetOneJob()
        {
            int jobId = 2;
            var mediatorMock = Substitute.For<IMediator>();

            var jobCtrl = Substitute.For<JobController>(mediatorMock);

            jobCtrl.Get(jobId);
            var arg = Arg.Any<IndexJobQuery>();
            jobCtrl.Received().Query(arg);
        }

        [Test]
        public void Should_CallAddJobCommand_With_AddJob()
        {
            int jobId = 2;
            var mediatorMock = Substitute.For<IMediator>();

            var jobCtrl = Substitute.For<JobController>(mediatorMock);

            var arg = Arg.Any<AddJobCommand>();
            jobCtrl.Post(arg);
            mediatorMock.Received(1);
        }
    }
}
