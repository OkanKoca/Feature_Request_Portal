using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Feature_Request_Portal.FeatureRequests;

namespace Feature_Request_Portal.Web.Pages.FeatureRequests
{
    public class IndexModel : Feature_Request_PortalPageModel   
    {
        public FeatureRequestStatus? StatusFilter { get; set; }
        public void OnGet()
        {
        }
    }
}
