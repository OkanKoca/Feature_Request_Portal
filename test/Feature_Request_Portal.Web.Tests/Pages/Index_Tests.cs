using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Feature_Request_Portal.Pages;

[Collection(Feature_Request_PortalTestConsts.CollectionDefinitionName)]
public class Index_Tests : Feature_Request_PortalWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
