namespace Feature_Request_Portal.Permissions;

public static class Feature_Request_PortalPermissions
{
    public const string GroupName = "Feature_Request_Portal";

    public static class FeatureRequests
    {
        public const string Default = GroupName + ".FeatureRequests";
        public const string Delete = Default + ".Delete";
        public const string ChangeStatus = Default + ".ChangeStatus";
    }
}
