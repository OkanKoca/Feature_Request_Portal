using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Feature_Request_Portal.Data;
using Volo.Abp.DependencyInjection;

namespace Feature_Request_Portal.EntityFrameworkCore;

public class EntityFrameworkCoreFeature_Request_PortalDbSchemaMigrator
    : IFeature_Request_PortalDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFeature_Request_PortalDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the Feature_Request_PortalDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Feature_Request_PortalDbContext>()
            .Database
            .MigrateAsync();
    }
}
