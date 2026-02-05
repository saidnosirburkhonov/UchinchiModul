namespace SocialMedia.Api.Entities;

public class Post
{
    public Guid PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
