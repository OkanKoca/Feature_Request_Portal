using System.Threading.Tasks;

namespace Feature_Request_Portal.Data;

public interface IFeature_Request_PortalDbSchemaMigrator
{
    Task MigrateAsync();
}
