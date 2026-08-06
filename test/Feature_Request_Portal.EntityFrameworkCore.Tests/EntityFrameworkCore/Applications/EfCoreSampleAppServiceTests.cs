using Feature_Request_Portal.Samples;
using Xunit;

namespace Feature_Request_Portal.EntityFrameworkCore.Applications;

[Collection(Feature_Request_PortalTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<Feature_Request_PortalEntityFrameworkCoreTestModule>
{

}
