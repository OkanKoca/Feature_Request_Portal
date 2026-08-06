using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Feature_Request_Portal.Authors;
using Feature_Request_Portal.Books;
namespace Feature_Request_Portal.Web;
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalWebMappers : MapperBase<BookDto, CreateUpdateBookDto>
{
    public override partial CreateUpdateBookDto Map(BookDto source);
    public override partial void Map(BookDto source, CreateUpdateBookDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class Feature_Request_PortalAuthorDtoToCreateUpdateAuthorDtoMapper : MapperBase<AuthorDto, CreateUpdateAuthorDto>
{
    public override partial CreateUpdateAuthorDto Map(AuthorDto source);
    public override partial void Map(AuthorDto source, CreateUpdateAuthorDto destination);
}
