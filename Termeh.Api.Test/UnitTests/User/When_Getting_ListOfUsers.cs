using JobTrack.Api.Controllers;
using JobTrack.Api.Data.Queries.User;
using NSubstitute;
using NUnit.Framework;
using ShortBus;

namespace Termeh.Api.Test.UnitTests.User
{
    [TestFixture]
    public class When_Getting_ListOfUsers
    {
        [Test]
        public void Should_Call_ShowUsersQuery_With_GetAll()
        {
            var mediatorMock = Substitute.For<IMediator>();

            var userCtrl = Substitute.For<UserController>(mediatorMock);

            userCtrl.Get();
            var arg = Arg.Any<ShowUsersQuery>();
            //userCtrl.Received().Query(arg);
        }
    }
}