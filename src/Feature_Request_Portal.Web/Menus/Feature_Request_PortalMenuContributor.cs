using System.Threading.Tasks;
using Feature_Request_Portal.Localization;
using Feature_Request_Portal.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
namespace Feature_Request_Portal.Web.Menus;
public class Feature_Request_PortalMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }
    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<Feature_Request_PortalResource>();
        //Ana sayfa zaten talep listesine yonlendirdigi icin ayri bir "Home" menu ogesi yok.
        context.Menu.AddItem(
            new ApplicationMenuItem(
                Feature_Request_PortalMenus.FeatureRequests,
                l["Menu:FeatureRequests"],
                url: "/FeatureRequests",
                icon: "fa fa-lightbulb",
                order: 1
            )
        );

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;
        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 8);

        return Task.CompletedTask;
    }
}
