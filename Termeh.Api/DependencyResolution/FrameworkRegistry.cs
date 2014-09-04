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
            //For(typeof(IdentityUser<int, TermehUserLogin, TermehUserRole, TermehUserClaim>)).Use(typeof(JobTrackDbContext)).CtorDependency<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["JobTrackDbContext"].Name);
            For<DbContext>().Use<JobTrackDbContext>().Ctor<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["JobTrackDbContext"].Name);
            For<ILog>().Use(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType));
            For<AutoMapper.IMappingEngine>().Use(() => AutoMapper.Mapper.Engine);
        }
    }
}