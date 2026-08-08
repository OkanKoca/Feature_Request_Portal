using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Feature_Request_Portal.Comments
{
    public class Comment : CreationAuditedEntity<Guid>
    {
        public Guid FeatureRequestId { get; private set; }
        public string Text { get; private set; }
        protected Comment()
        {
        }
        public Comment(Guid id, Guid featureRequestId, string text) : base(id)
        {
            Check.NotNullOrWhiteSpace(text, nameof(text), CommentConsts.MaxTextLength, CommentConsts.MinTextLength);

            FeatureRequestId = featureRequestId;
            Text = text;
        }
    }
}
