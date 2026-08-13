using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Feature_Request_Portal.FeatureRequests;
using Feature_Request_Portal.Comments;

namespace Feature_Request_Portal;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalFeatureRequestToFeatureRequestDtoMapper : MapperBase<FeatureRequest, FeatureRequestDto>
{
    public override partial FeatureRequestDto Map(FeatureRequest source);
    public override partial void Map(FeatureRequest source, FeatureRequestDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalFeatureRequestToFeatureRequestDetailDto : MapperBase<FeatureRequest, FeatureRequestDetailDto>
{
    [MapperIgnoreTarget(nameof(FeatureRequestDetailDto.IsVotedByCurrentUser))]
    public override partial FeatureRequestDetailDto Map(FeatureRequest source);
    public override partial void Map(FeatureRequest source, FeatureRequestDetailDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalCommentToCommentDtoMapper : MapperBase<Comment, CommentDto>
{
    [MapperIgnoreTarget(nameof(CommentDto.CreatorName))]
    public override partial CommentDto Map(Comment source);
    public override partial void Map(Comment source, CommentDto destination);
}


