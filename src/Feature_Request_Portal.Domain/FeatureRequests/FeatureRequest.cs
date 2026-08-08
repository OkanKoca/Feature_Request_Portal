using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Feature_Request_Portal.Comments;
using Feature_Request_Portal.Votes;

namespace Feature_Request_Portal.FeatureRequests
{
    public class FeatureRequest : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public FeatureRequestStatus Status { get; private set; }
        public int VoteCount { get; private set; }
        private readonly List<Vote> _votes = new List<Vote>();
        public IReadOnlyCollection<Vote> Votes => _votes;
        private readonly List<Comment> _comments = new List<Comment>();
        public IReadOnlyCollection<Comment> Comments => _comments;

        protected FeatureRequest()
        {

        }

        public FeatureRequest(Guid id, string title, string? description) : base (id)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title), FeatureRequestConsts.MaxTitleLength, FeatureRequestConsts.MinTitleLength);
            Check.Length(description, nameof(description), FeatureRequestConsts.MaxDescriptionLength);

            Title = title;
            Description = description;
            Status = FeatureRequestStatus.Pending;
            VoteCount = 0;
        }


    }
}
