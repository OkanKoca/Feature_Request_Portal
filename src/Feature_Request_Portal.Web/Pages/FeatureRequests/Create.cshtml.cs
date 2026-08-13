using Feature_Request_Portal.FeatureRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Feature_Request_Portal.Web.Pages.FeatureRequests
{
    [Authorize]
    public class CreateModel : Feature_Request_PortalPageModel
    {
        [BindProperty]
        public CreateFeatureRequestDto FeatureRequest { get; set; } = new CreateFeatureRequestDto();
        private readonly IFeatureRequestAppService _featureRequestAppService;
        public CreateModel(IFeatureRequestAppService featureRequestAppService)
        {
            _featureRequestAppService = featureRequestAppService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var created = await _featureRequestAppService.CreateAsync(FeatureRequest);

            return RedirectToPage("Detail", new { id = created.Id });
        }
    }
}
