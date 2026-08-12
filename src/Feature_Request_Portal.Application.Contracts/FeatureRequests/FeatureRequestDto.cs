using System;
using Volo.Abp.Application.Dtos;

namespace Feature_Request_Portal.FeatureRequests
{
    public class FeatureRequestDto : CreationAuditedEntityDto<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public int VoteCount { get; set; }
        public FeatureRequestStatus Status { get; set; }
    }
}
