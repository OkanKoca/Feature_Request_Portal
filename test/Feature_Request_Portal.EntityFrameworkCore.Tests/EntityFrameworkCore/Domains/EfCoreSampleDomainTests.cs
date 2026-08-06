using Feature_Request_Portal.Samples;
using Xunit;

namespace Feature_Request_Portal.EntityFrameworkCore.Domains;

[Collection(Feature_Request_PortalTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Feature_Request_PortalEntityFrameworkCoreTestModule>
{

}
