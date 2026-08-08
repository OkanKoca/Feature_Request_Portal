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
            var featureRequest = CreateValidFeatureRequest();
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
            var featureRequest = CreateValidFeatureRequest();
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
            var featureRequest = CreateValidFeatureRequest();
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            featureRequest.AddVote(guidGenerator, userId1);
            // Act & Assert
            Should.NotThrow(() => featureRequest.AddVote(guidGenerator, userId2));
            featureRequest.VoteCount.ShouldBe(2);
        }

        [Fact]
        public void Should_Add_Comment_When_AddComment()
        {
            // Arrange
            var guidGenerator = SimpleGuidGenerator.Instance;
            var featureRequest = CreateValidFeatureRequest();
            // Act
            featureRequest.AddComment(guidGenerator, ValidCommentText);
            // Assert
            featureRequest.Comments.Count.ShouldBe(1);
        }

        [Fact]
        public void Should_Throw_Exception_When_Setting_Invalid_Status()
        {
            // Arrange
            var featureRequest = CreateValidFeatureRequest();
            // Act & Assert
            Should.Throw<BusinessException>(() => featureRequest.SetStatus((FeatureRequestStatus)999)).Code.ShouldBe(Feature_Request_PortalDomainErrorCodes.InvalidStatus);
        }

        [Fact]
        public void Should_Be_Pending_When_Created()
        {
            // Arrange
            var featureRequest = CreateValidFeatureRequest();
            // Act & Assert
            featureRequest.Status.ShouldBe(FeatureRequestStatus.Pending);
        }

        [Fact]
        public void Should_Set_Status_When_SetStatus()
        {
            // Arrange
            var featureRequest = CreateValidFeatureRequest();
            // Act
            featureRequest.SetStatus(FeatureRequestStatus.Approved);
            // Assert
            featureRequest.Status.ShouldBe(FeatureRequestStatus.Approved);
        }

        private static FeatureRequest CreateValidFeatureRequest(string title = "Test Feature", 
            string description = "This is a test feature request.")
        {
            var guidGenerator = SimpleGuidGenerator.Instance;
            return new FeatureRequest(guidGenerator.Create(), title, description);
        }

        private const string ValidCommentText = "This is a valid comment text that is within the allowed length limits and written for tests but it is tough to reach 100 characters :). ";

    }
}
