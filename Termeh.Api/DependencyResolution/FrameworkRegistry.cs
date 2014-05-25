using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using JobTrack.Api.Data.Context;
using JobTrack.Api.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StructureMap.Configuration.DSL;
using log4net;

namespace JobTrack.Api.DependencyResolution
{
    public class FrameworkRegistry : Registry
    {
        public FrameworkRegistry()
        {
            For<DbContext>().Use<JobTrackDbContext>().Ctor<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["JobTrackDbContext"].Name);
            //For(typeof(IdentityUser<int, GuidUserLogin, GuidUserRole, GuidUserClaim>)).Use(typeof(JobTrackDbContext)).CtorDependency<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["JobTrackDbContext"].Name);
            For<ILog>().Use(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType));
        }
    }
}