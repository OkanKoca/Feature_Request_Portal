using System;
using System.Threading.Tasks;
using Feature_Request_Portal.Authors;
using Microsoft.AspNetCore.Mvc;
namespace Feature_Request_Portal.Web.Pages.Authors;
public class EditModalModel : Feature_Request_PortalPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    [BindProperty]
    public CreateUpdateAuthorDto Author { get; set; }
    private readonly IAuthorAppService _authorAppService;
    public EditModalModel(IAuthorAppService authorAppService)
    {
        _authorAppService = authorAppService;
    }
    public async Task OnGetAsync()
    {
        var authorDto = await _authorAppService.GetAsync(Id);
        Author = ObjectMapper.Map<AuthorDto, CreateUpdateAuthorDto>(authorDto);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _authorAppService.UpdateAsync(Id, Author);
        return NoContent();
    }
}
