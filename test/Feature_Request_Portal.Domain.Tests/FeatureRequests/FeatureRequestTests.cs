using System;
using Xunit;
using Shouldly;
using Volo.Abp;
using Volo.Abp.Guids;

namespace Feature_Request_Portal.FeatureRequests
{
    public class FeatureRequestTests
    {
        [Fact]
        public void Should_Increase_VoteCount_When_AddVote()
        {
            // Arrange
            var guidGenerator = SimpleGuidGenerator.Instance;
            var featureRequest = new FeatureRequest(Guid.NewGuid(), "Test Feature", "This is a test feature request.");
            var userId = Guid.NewGuid();
            // Act
            featureRequest.AddVote(guidGenerator, userId);
            // Assert
            featureRequest.VoteCount.ShouldBe(1);
            featureRequest.Votes.Count.ShouldBe(1);
        }

        [Fact]
        public void Should_Throw_Exception_When_Adding_Vote_That_Already_Exists()
        {
            // Arrange
            var guidGenerator = SimpleGuidGenerator.Instance;
            var featureRequest = new FeatureRequest(Guid.NewGuid(), "Test Feature", "This is a test feature request.");
            var userId = Guid.NewGuid();
            featureRequest.AddVote(guidGenerator, userId);
            // Act & Assert
            Should.Throw<BusinessException>(() => featureRequest.AddVote(guidGenerator, userId)).Code.ShouldBe(Feature_Request_PortalDomainErrorCodes.AlreadyVoted);
        }

        [Fact]
        public void Should_Not_Throw_Exception_When_Adding_Vote_From_Different_User()
        {
            // Arrange
            var guidGenerator = SimpleGuidGenerator.Instance;
            var featureRequest = new FeatureRequest(Guid.NewGuid(), "Test Feature", "This is a test feature request.");
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            featureRequest.AddVote(guidGenerator, userId1);
            // Act & Assert
            Should.NotThrow(() => featureRequest.AddVote(guidGenerator, userId2));
            featureRequest.VoteCount.ShouldBe(2);
        }
    }
}
