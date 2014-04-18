using StructureMap;
using StructureMap.Graph;

namespace JobTrack.Api.DependencyResolution
{
    public static class IocInitializer
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
                                                     {
                                                         scan.TheCallingAssembly();
                                                         scan.AssembliesFromApplicationBaseDirectory();
                                                         scan.WithDefaultConventions();
                                                         scan.LookForRegistries();
                                                     }));

            return ObjectFactory.Container;
        }
    }
}