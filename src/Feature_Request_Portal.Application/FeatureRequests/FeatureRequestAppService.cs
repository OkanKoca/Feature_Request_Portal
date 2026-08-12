using Feature_Request_Portal.Comments;
using Feature_Request_Portal.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Feature_Request_Portal.FeatureRequests
{
    [Authorize]
    public class FeatureRequestAppService : ApplicationService, IFeatureRequestAppService
    {
        private readonly IRepository<FeatureRequest, Guid> _featureRequestRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private static readonly string[] AllowedSortings = 
        { 
            "CreationTime DESC",
            "CreationTime ASC",
            "Title ASC",
            "Title DESC", 
            "VoteCount DESC",
            "VoteCount ASC"
        };
        private const string DefaultSorting = "CreationTime DESC";
        public FeatureRequestAppService(IRepository<FeatureRequest, Guid> featureRequestRepository, IRepository<IdentityUser, Guid> userRepository)
        {
            _featureRequestRepository = featureRequestRepository;
            _userRepository = userRepository;
        }
        
        [AllowAnonymous]
        public async Task<PagedResultDto<FeatureRequestDto>> GetListAsync(GetFeatureRequestListInput input)
        {
            var queryable = await _featureRequestRepository.GetQueryableAsync();

            var status = input.Status;

            queryable = queryable.WhereIf(!CurrentUser.IsAuthenticated, x => x.Status == FeatureRequestStatus.Approved).WhereIf(input.Status.HasValue, x => x.Status == status);

            var totalCount = await AsyncExecuter.CountAsync(queryable);
           
            var featureRequests = await AsyncExecuter.ToListAsync(queryable.OrderBy(NormalizeSorting(input.Sorting)).PageBy(input.SkipCount, input.MaxResultCount));

            return new PagedResultDto<FeatureRequestDto>(
                totalCount,
                ObjectMapper.Map<List<FeatureRequest>, List<FeatureRequestDto>>(featureRequests)
            );
        }
        [AllowAnonymous]
        public async Task<FeatureRequestDetailDto> GetAsync(Guid id)
        {
            var featureRequest= await _featureRequestRepository.GetAsync(id);

            if(!CurrentUser.IsAuthenticated && featureRequest.Status != FeatureRequestStatus.Approved)
            {
                throw new EntityNotFoundException(typeof(FeatureRequest), id);
            }

            var featureRequestDetailDto = ObjectMapper.Map<FeatureRequest, FeatureRequestDetailDto>(featureRequest);
            featureRequestDetailDto.IsVotedByCurrentUser = featureRequest.Votes.Any(v => v.CreatorId == CurrentUser.Id);

            var commentCreators = featureRequest.Comments.Select(c => c.CreatorId).Distinct().ToList();
            var users = await _userRepository.GetListAsync(u => commentCreators.Contains(u.Id));
            var userDictionary = users.ToDictionary(u => u.Id, u => u.UserName);

            var commentDtos = featureRequestDetailDto.Comments;

            foreach (var commentDto in commentDtos)
            {
                if (commentDto.CreatorId.HasValue)
                {
                    commentDto.CreatorName = userDictionary.GetValueOrDefault(commentDto.CreatorId.Value) ?? string.Empty;
                }
            }

            featureRequestDetailDto.Comments = commentDtos.OrderByDescending(c => c.CreationTime).ToList();

            return featureRequestDetailDto;
        }

        public async Task<FeatureRequestDto> CreateAsync(CreateFeatureRequestDto input)
        {
            var featureRequest = new FeatureRequest(GuidGenerator.Create(), input.Title, input.Description);

            await _featureRequestRepository.InsertAsync(featureRequest, autoSave: true);

            return ObjectMapper.Map<FeatureRequest, FeatureRequestDto>(featureRequest);
        }

        public async Task<int> VoteAsync(Guid id)
        {
            var featureRequest = await _featureRequestRepository.GetAsync(id);
            featureRequest.AddVote(GuidGenerator, CurrentUser.GetId());

            await _featureRequestRepository.UpdateAsync(featureRequest, autoSave: true);

            return featureRequest.VoteCount;
        }

        public async Task<CommentDto> AddCommentAsync(Guid id, CreateCommentDto input)
        {
            var featureRequest = await _featureRequestRepository.GetAsync(id);
            var comment = featureRequest.AddComment(GuidGenerator, input.Text);

            await _featureRequestRepository.UpdateAsync(featureRequest, autoSave: true);

            var commentDto = ObjectMapper.Map<Comment, CommentDto>(comment);
            commentDto.CreatorName = CurrentUser.UserName ?? string.Empty;
            return commentDto;
        }
        [Authorize(Feature_Request_PortalPermissions.FeatureRequests.ChangeStatus)]
        public async Task ChangeStatusAsync(Guid id, FeatureRequestStatus status)
        {
            var featureRequest = await _featureRequestRepository.GetAsync(id, false);

            featureRequest.SetStatus(status);

            await _featureRequestRepository.UpdateAsync(featureRequest, autoSave: true);
        }

        [Authorize(Feature_Request_PortalPermissions.FeatureRequests.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _featureRequestRepository.DeleteAsync(id, autoSave: true);
        }

        private static string NormalizeSorting(string? sorting)
        {
            if (string.IsNullOrWhiteSpace(sorting))
            {
                return DefaultSorting;
            }
            var sortingParts = sorting.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var propertyName = sortingParts[0];

            var direction = sortingParts.Length > 1 ? sortingParts[1].ToUpperInvariant() : "DESC";

            return AllowedSortings.FirstOrDefault(s => s.StartsWith(propertyName, StringComparison.OrdinalIgnoreCase) && s.EndsWith(direction, StringComparison.OrdinalIgnoreCase)) ?? DefaultSorting;
        }
    }
}
