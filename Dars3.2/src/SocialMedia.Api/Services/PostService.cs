using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services;

public class PostService : IPostService
{
    public PostGetDto CreatePost(PostCreateDto postCreateDto)
    {
        var post = new PostGetDto()
        {
            PostId = Guid.NewGuid()
            
        };
        return post;
    }

    public bool DeletePost(Guid postId)
    {
        throw new NotImplementedException();
    }

    public List<PostGetDto> GetAllPosts()
    {
        throw new NotImplementedException();
    }

    public PostGetDto? GetPostById(Guid postId)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePost(PostUpdateDto postUpdateDto)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePost(Guid postId, PostUpdateDto postUpdateDto)
    {
        throw new NotImplementedException();
    }
}
