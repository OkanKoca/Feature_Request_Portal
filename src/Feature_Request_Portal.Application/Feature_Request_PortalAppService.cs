using Feature_Request_Portal.Localization;
using Volo.Abp.Application.Services;

namespace Feature_Request_Portal;

/* Inherit your application services from this class.
 */
public abstract class Feature_Request_PortalAppService : ApplicationService
{
    protected Feature_Request_PortalAppService()
    {
        LocalizationResource = typeof(Feature_Request_PortalResource);
    }
}
