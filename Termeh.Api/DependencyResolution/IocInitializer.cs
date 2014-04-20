using ShortBus;
using StructureMap;

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
                                                         scan.AddAllTypesOf(typeof(IQueryHandler<,>));
                                                         scan.AddAllTypesOf(typeof(ICommandHandler<>));
                                                     }));

            return ObjectFactory.Container;
        }
    }
}