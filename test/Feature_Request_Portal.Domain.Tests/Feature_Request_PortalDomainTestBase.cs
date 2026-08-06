using Volo.Abp.Modularity;

namespace Feature_Request_Portal;

/* Inherit from this class for your domain layer tests. */
public abstract class Feature_Request_PortalDomainTestBase<TStartupModule> : Feature_Request_PortalTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
