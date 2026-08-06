using Volo.Abp.Modularity;

namespace Feature_Request_Portal;

public abstract class Feature_Request_PortalApplicationTestBase<TStartupModule> : Feature_Request_PortalTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
