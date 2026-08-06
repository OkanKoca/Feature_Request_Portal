using Feature_Request_Portal.Books;
using Xunit;

namespace Feature_Request_Portal.EntityFrameworkCore.Applications.Books;

[Collection(Feature_Request_PortalTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<Feature_Request_PortalEntityFrameworkCoreTestModule>
{

}