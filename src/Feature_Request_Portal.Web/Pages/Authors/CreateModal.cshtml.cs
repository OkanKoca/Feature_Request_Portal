using System.Threading.Tasks;
using Feature_Request_Portal.Authors;
using Microsoft.AspNetCore.Mvc;
namespace Feature_Request_Portal.Web.Pages.Authors
{
    public class CreateModalModel : Feature_Request_PortalPageModel
    {
        [BindProperty]
        public CreateUpdateAuthorDto Author { get; set; }
        private readonly IAuthorAppService _authorAppService;
        public CreateModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }
        public void OnGet()
        {
            Author = new CreateUpdateAuthorDto();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _authorAppService.CreateAsync(Author);
            return NoContent();
        }
    }
}
