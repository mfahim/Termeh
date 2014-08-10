﻿using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Commands;
using NSubstitute;
using NUnit.Framework;
using ShortBus;

namespace Termeh.Api.Test.UnitTests.Job
{
    [TestFixture]
    public class WhenCreatingAJob
    {
        [Test]
        public void ShouldReturnTrue()
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
    }
}