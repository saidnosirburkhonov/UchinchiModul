using Dars3._3.Dtos;

namespace Dars3._3.Services;

public interface IPostService
{
    public Guid AddPost(PostCreateDto postCreateDto, string token);
    public List<PostGetDto> GetAllPosts(string  token);
    public List<PostGetDto>? GetAllPostsByAdmin(string token);
    public PostGetDto? GetPostById(Guid postId, string token);
    public bool DeletePost(Guid postId, string token);
    public bool UpdatePost(Guid postId,  PostCreateDto postCreateDto, string token);

}