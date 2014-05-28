using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using JobTrack.Api.Data.Context;
using JobTrack.Api.Data.Models;
using JobTrack.Api.DependencyResolution;
using StructureMap;

namespace JobTrack.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            StructuremapMvc.Start();

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ApplicationConverterBootStrapper.Start();

            var t = new JobTrackDbContext(ConfigurationManager.ConnectionStrings["JobTrackDbContext"].Name);
            var df = ObjectFactory.GetInstance<DbContext>();
            var er = df.Set<Job>().ToList();
            //sqlInitial.InitializeDatabase((JobTrackDbContext)new JobTrackDbContext(ConfigurationManager.ConnectionStrings["JobTrackDbContext"].Name));
            //ObjectFactory.GetInstance<DbContext>()
        }
    }
}