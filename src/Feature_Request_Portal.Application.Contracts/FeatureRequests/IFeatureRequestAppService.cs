using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Feature_Request_Portal.Comments;

namespace Feature_Request_Portal.FeatureRequests
{
    public interface IFeatureRequestAppService : IApplicationService
    {
        Task<PagedResultDto<FeatureRequestDto>> GetListAsync(GetFeatureRequestListInput input);
        Task<FeatureRequestDetailDto> GetAsync(Guid id);
        Task<FeatureRequestDto> CreateAsync(CreateFeatureRequestDto input);
        Task<int> VoteAsync(Guid id);
        Task<CommentDto> AddCommentAsync(Guid id, CreateCommentDto input);
        Task ChangeStatusAsync(Guid id, FeatureRequestStatus status);
        Task DeleteAsync(Guid id);

    }
}
