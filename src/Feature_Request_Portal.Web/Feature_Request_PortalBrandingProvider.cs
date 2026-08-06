using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Feature_Request_Portal.Localization;

namespace Feature_Request_Portal.Web;

[Dependency(ReplaceServices = true)]
public class Feature_Request_PortalBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<Feature_Request_PortalResource> _localizer;

    public Feature_Request_PortalBrandingProvider(IStringLocalizer<Feature_Request_PortalResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
