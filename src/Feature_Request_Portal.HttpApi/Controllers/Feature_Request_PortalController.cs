using Feature_Request_Portal.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Feature_Request_Portal.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Feature_Request_PortalController : AbpControllerBase
{
    protected Feature_Request_PortalController()
    {
        LocalizationResource = typeof(Feature_Request_PortalResource);
    }
}
