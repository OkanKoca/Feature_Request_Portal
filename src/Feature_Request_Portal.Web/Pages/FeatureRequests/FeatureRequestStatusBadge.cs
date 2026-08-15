using Feature_Request_Portal.FeatureRequests;

namespace Feature_Request_Portal.Web.Pages.FeatureRequests;

public static class FeatureRequestStatusBadge
{
    /// <summary>
    /// Returns the Bootstrap background class used to render a status badge.
    /// The list page repeats this mapping in Index.js; keep both in sync.
    /// </summary>
    public static string CssClass(FeatureRequestStatus status)
    {
        return status switch
        {
            FeatureRequestStatus.Pending => "bg-secondary",
            FeatureRequestStatus.Approved => "bg-success",
            FeatureRequestStatus.Rejected => "bg-danger",
            FeatureRequestStatus.Planned => "bg-primary",
            FeatureRequestStatus.Completed => "bg-info",
            FeatureRequestStatus.Cancelled => "bg-dark",
            _ => "bg-secondary"
        };
    }
}
