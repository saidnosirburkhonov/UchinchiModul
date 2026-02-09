using SocialMedia_Project_.Api.Entities;

namespace SocialMedia_Project_.Api.Services;

public interface IPostRepository
{
    public List<Post>? GetAllPosts();
    public void SaveAllPosts(List<Post> posts);


}