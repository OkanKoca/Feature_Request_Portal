using System;
using Volo.Abp.Application.Dtos;


namespace Feature_Request_Portal.Comments
{
    public class CommentDto : CreationAuditedEntityDto<Guid>
    {
        public string CreatorName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

    }
}
