using System.Web.Http;
using StructureMap;

namespace JobTrack.Api.DependencyResolution
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            var container = (IContainer)IocInitializer.Initialize();
            //DependencyResolver.SetResolver(new IocDependencyResolver(container));
            // this override is needed because WebAPI is not using DependencyResolver to build controllers 
            GlobalConfiguration.Configuration.DependencyResolver = new IocDependencyResolver(container);
        }
    }
}