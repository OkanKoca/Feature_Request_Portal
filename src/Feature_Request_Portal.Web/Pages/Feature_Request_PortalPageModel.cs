using Feature_Request_Portal.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Feature_Request_Portal.Web.Pages;

public abstract class Feature_Request_PortalPageModel : AbpPageModel
{
    protected Feature_Request_PortalPageModel()
    {
        LocalizationResourceType = typeof(Feature_Request_PortalResource);
    }
}
