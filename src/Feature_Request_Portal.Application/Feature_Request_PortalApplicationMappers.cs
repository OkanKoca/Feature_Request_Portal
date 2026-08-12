using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Feature_Request_Portal.Authors;
using Feature_Request_Portal.Books;
using Feature_Request_Portal.FeatureRequests;
using Feature_Request_Portal.Comments;

namespace Feature_Request_Portal;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    [MapperIgnoreTarget(nameof(BookDto.AuthorName))]
    public override partial BookDto Map(Book source);

    [MapperIgnoreTarget(nameof(BookDto.AuthorName))]
    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalAuthorToAuthorDtoMapper : MapperBase<Author, AuthorDto>
{
    public override partial AuthorDto Map(Author source);

    public override partial void Map(Author source, AuthorDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalCreateUpdateAuthorDtoToAuthorMapper : MapperBase<CreateUpdateAuthorDto, Author>
{
    public override partial Author Map(CreateUpdateAuthorDto source);

    public override partial void Map(CreateUpdateAuthorDto source, Author destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalAuthorToAuthorExcelDtoMapper : MapperBase<Author, AuthorExcelDto>
{
    public override partial AuthorExcelDto Map(Author source);

    public override partial void Map(Author source, AuthorExcelDto destination);
}

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


