using Feature_Request_Portal.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Feature_Request_Portal.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Feature_Request_PortalEntityFrameworkCoreModule),
    typeof(Feature_Request_PortalApplicationContractsModule)
)]
public class Feature_Request_PortalDbMigratorModule : AbpModule
{
}
