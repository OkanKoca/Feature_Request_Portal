using Feature_Request_Portal.Comments;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Feature_Request_Portal.FeatureRequests
{
    public class FeatureRequestDetailDto : CreationAuditedEntityDto<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int VoteCount { get; set; }
        public FeatureRequestStatus Status { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public bool IsVotedByCurrentUser { get; set; } = false;
    }
}
