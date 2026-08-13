using Feature_Request_Portal.FeatureRequests;
using Feature_Request_Portal.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Feature_Request_Portal.Web.Pages.FeatureRequests
{
    public class DetailModel : Feature_Request_PortalPageModel
    {
        public FeatureRequestDetailDto FeatureRequest { get; set; }
        [BindProperty]
        public CreateCommentDto NewComment { get; set; } = new CreateCommentDto();
        [BindProperty]
        public FeatureRequestStatus NewStatus { get; set; }

        private readonly IFeatureRequestAppService _featureRequestAppService;

        public DetailModel(IFeatureRequestAppService featureRequestAppService)
        {
            _featureRequestAppService = featureRequestAppService;
        }

        public async Task OnGetAsync(Guid id) 
        {
            FeatureRequest = await _featureRequestAppService.GetAsync(id);
            NewStatus = FeatureRequest.Status;
        }

        public async Task<IActionResult> OnPostCommentAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(id);
                return Page();
            }

            await _featureRequestAppService.AddCommentAsync(id, NewComment);
            return RedirectToPage(new { id });
        }

        public async Task<IActionResult> OnPostStatusAsync(Guid id)
        {
            await _featureRequestAppService.ChangeStatusAsync(id, NewStatus);
            return RedirectToPage(new { id });
        }
    }
}
