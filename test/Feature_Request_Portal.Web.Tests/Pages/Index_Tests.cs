using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Feature_Request_Portal.Pages;

[Collection(Feature_Request_PortalTestConsts.CollectionDefinitionName)]
public class Index_Tests : Feature_Request_PortalWebTestBase
{
    [Fact]
    public async Task Home_Should_Redirect_To_FeatureRequest_List()
    {
        var response = await GetResponseAsync("/", HttpStatusCode.Redirect);

        response.Headers.Location.ShouldNotBeNull();
        response.Headers.Location.ToString().ShouldContain("/FeatureRequests");
    }

    [Fact]
    public async Task FeatureRequest_List_Should_Be_Accessible_Anonymously()
    {
        var response = await GetResponseAsStringAsync("/FeatureRequests");

        response.ShouldNotBeNull();
    }
}
