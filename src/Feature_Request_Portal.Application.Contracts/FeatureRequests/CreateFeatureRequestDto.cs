using System.ComponentModel.DataAnnotations;

namespace Feature_Request_Portal.FeatureRequests
{
    public class CreateFeatureRequestDto
    {
        [Required]
        [StringLength(FeatureRequestConsts.MaxTitleLength, MinimumLength = FeatureRequestConsts.MinTitleLength)]
        public string Title { get; set; } = string.Empty;
        [StringLength(FeatureRequestConsts.MaxDescriptionLength)]
        public string? Description { get; set; }

    }
}
