using System;
using Volo.Abp.Domain.Repositories;
using Xunit;
using Feature_Request_Portal.FeatureRequests;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Shouldly;

namespace Feature_Request_Portal.EntityFrameworkCore.FeatureRequests
{
    [Collection(Feature_Request_PortalTestConsts.CollectionDefinitionName)]
    public class FeatureRequestRepositoryTests : Feature_Request_PortalEntityFrameworkCoreTestBase
    {
        private readonly IRepository<FeatureRequest, Guid> _featureRequestRepository;

        public FeatureRequestRepositoryTests()
        {
            _featureRequestRepository = GetRequiredService<IRepository<FeatureRequest, Guid>>();
        }

        [Fact]
        public async Task Should_Add_Comment_and_Vote()
        {
            Guid featureRequestId = Guid.NewGuid();

            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange
                var guidGenerator = SimpleGuidGenerator.Instance;
                var featureRequest = new FeatureRequest(guidGenerator.Create(), "Test Feature Request", "This is a test feature request.");
                await _featureRequestRepository.InsertAsync(featureRequest);
                featureRequestId = featureRequest.Id;
                var userId = Guid.NewGuid();
                // Act
                featureRequest.AddVote(guidGenerator, userId);
                featureRequest.AddComment(guidGenerator, "" +
                    "This is a test comment." +
                    "This is a test comment." +
                    "This is a test comment." +
                    "This is a test comment." +
                    "This is a test comment." +
                    "This is a test comment.");
            });

            await WithUnitOfWorkAsync(async () =>
            {
                // Assert
                var featureRequest = await _featureRequestRepository.GetAsync(f => f.Id == featureRequestId);
                featureRequest.ShouldNotBeNull();
                featureRequest.VoteCount.ShouldBe(1);
                featureRequest.Votes.Count.ShouldBe(1);
                featureRequest.Comments.Count.ShouldBe(1);
            });
        }
    }
}
