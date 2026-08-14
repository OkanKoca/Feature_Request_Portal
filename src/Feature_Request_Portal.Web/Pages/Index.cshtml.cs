using Microsoft.AspNetCore.Mvc;

namespace Feature_Request_Portal.Web.Pages;

public class IndexModel : Feature_Request_PortalPageModel
{
    public IActionResult OnGet()
    {
        return RedirectToPage("/FeatureRequests/Index");
    }
}
