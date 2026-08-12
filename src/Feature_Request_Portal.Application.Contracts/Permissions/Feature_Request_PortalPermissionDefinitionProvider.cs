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

        var booksPermission = myGroup.AddPermission(Feature_Request_PortalPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(Feature_Request_PortalPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(Feature_Request_PortalPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(Feature_Request_PortalPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = myGroup.AddPermission(Feature_Request_PortalPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(Feature_Request_PortalPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(Feature_Request_PortalPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(Feature_Request_PortalPermissions.Authors.Delete, L("Permission:Authors.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(Feature_Request_PortalPermissions.MyPermission1, L("Permission:MyPermission1"));

        var featureRequestsPermission = myGroup.AddPermission(Feature_Request_PortalPermissions.FeatureRequests.Default, L("Permission:FeatureRequests"));
        featureRequestsPermission.AddChild(Feature_Request_PortalPermissions.FeatureRequests.Delete, L("Permission:FeatureRequests.Delete"));
        featureRequestsPermission.AddChild(Feature_Request_PortalPermissions.FeatureRequests.ChangeStatus, L("Permission:FeatureRequests.ChangeStatus"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Feature_Request_PortalResource>(name);
    }
}
