using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Feature_Request_Portal.Data;

/* This is used if database provider does't define
 * IFeature_Request_PortalDbSchemaMigrator implementation.
 */
public class NullFeature_Request_PortalDbSchemaMigrator : IFeature_Request_PortalDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
