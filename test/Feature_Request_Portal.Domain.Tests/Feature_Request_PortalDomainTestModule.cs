using Volo.Abp.Modularity;

namespace Feature_Request_Portal;

[DependsOn(
    typeof(Feature_Request_PortalDomainModule),
    typeof(Feature_Request_PortalTestBaseModule)
)]
public class Feature_Request_PortalDomainTestModule : AbpModule
{

}
