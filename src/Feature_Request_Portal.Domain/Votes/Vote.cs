using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Feature_Request_Portal.Votes
{
    public class Vote : CreationAuditedEntity<Guid>
    {
        public Guid FeatureRequestId { get; private set; }
        protected Vote()
        {
        }
        public Vote(Guid id, Guid featureRequestId) : base(id)
        {
            FeatureRequestId = featureRequestId;
        }
    }
}
