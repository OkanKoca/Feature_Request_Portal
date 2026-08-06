using Microsoft.AspNetCore.Builder;
using Feature_Request_Portal;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("Feature_Request_Portal.Web.csproj"); 
await builder.RunAbpModuleAsync<Feature_Request_PortalWebTestModule>(applicationName: "Feature_Request_Portal.Web");

public partial class Program
{
}
