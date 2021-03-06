﻿using System.Data.Entity;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using JobTrack.Api.Data.Context;
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

            var ctx = ObjectFactory.GetInstance<DbContext>();
            Database.SetInitializer(new ApplicationDbInitializer((JobTrackDbContext)ctx));
        }
    }
}