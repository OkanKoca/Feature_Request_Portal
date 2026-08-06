using Volo.Abp.Modularity;

namespace Feature_Request_Portal;

[DependsOn(
    typeof(Feature_Request_PortalApplicationModule),
    typeof(Feature_Request_PortalDomainTestModule)
)]
public class Feature_Request_PortalApplicationTestModule : AbpModule
{

}
