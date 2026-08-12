using System.ComponentModel.DataAnnotations;


namespace Feature_Request_Portal.Comments
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(CommentConsts.MaxTextLength, MinimumLength = CommentConsts.MinTextLength)]
        public string Text { get; set; } = string.Empty;
    }
}
