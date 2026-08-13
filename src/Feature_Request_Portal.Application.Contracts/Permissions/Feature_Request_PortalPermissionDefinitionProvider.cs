using Feature_Request_Portal.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Feature_Request_Portal.Permissions;

public class Feature_Request_PortalPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Feature_Request_PortalPermissions.GroupName);

        var featureRequestsPermission = myGroup.AddPermission(Feature_Request_PortalPermissions.FeatureRequests.Default, L("Permission:FeatureRequests"));
        featureRequestsPermission.AddChild(Feature_Request_PortalPermissions.FeatureRequests.Delete, L("Permission:FeatureRequests.Delete"));
        featureRequestsPermission.AddChild(Feature_Request_PortalPermissions.FeatureRequests.ChangeStatus, L("Permission:FeatureRequests.ChangeStatus"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Feature_Request_PortalResource>(name);
    }
}
