using SocialMedia_Project_.Api.Dtos;
using SocialMedia_Project_.Api.Entities;

namespace SocialMedia_Project_.Api.Services;

public class PostService : IPostService
{

    private readonly IPostRepository PostRepository;
    private readonly IUserRepository UserRepository;
    private readonly ITokenService TokenService;
    public PostService()
    {
        PostRepository = new PostRepository();
        UserRepository = new UserRepository();
        TokenService = new TokenService();
    }

    public Guid AddPost(PostCreateDto postCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if(userBlocked == true)
        {
            return Guid.Empty;
        }

        var post = new Post()
        {
            PostId = Guid.NewGuid(),
            Title = postCreateDto.Title,
            Content = postCreateDto.Content,
            CreatedTime = DateTime.UtcNow,
            UpdatedTime = DateTime.UtcNow,
            UserId = Guid.Parse(tokenResult.userId),
        };

        var userExists = false;
        var users = UserRepository.GetAllUsers();
        foreach( var user in users)
        {
            if(user.UserId.ToString() ==  tokenResult.userId)
            {
                userExists = true;
                break;
            }
        }
        if(userExists == true)
        {
            var posts = PostRepository.GetAllPosts();
            posts.Add(post);
            PostRepository.SaveAllPosts(posts);

        }
        return post.PostId;
    }

    public bool DeletePost(Guid postId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));
        if(userBlocked == true)
        {
            return false; 
        }
        var posts = PostRepository.GetAllPosts();
        foreach (var post in posts)
        {
            if(post.PostId == postId && post.UserId.ToString() == tokenResult.userId)
            {
                posts.Remove(post);
                PostRepository.SaveAllPosts(posts);
                return true;
            }
        }
        return false;
    }

    public List<PostGetDto> GetAllPosts(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var postGetDtos = new List<PostGetDto>();
        var posts = PostRepository.GetAllPosts();
        foreach (var post in posts)
        {
            if(post.UserId.ToString() == tokenResult.userId)
            {
                var postDto = new PostGetDto()
                {
                    PostId = post.PostId,
                    UserId = post.UserId,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                };
                postGetDtos.Add(postDto);
            }
        }
        postGetDtos = postGetDtos.OrderBy(x => x.CreatedTime).ToList();
        return postGetDtos;
    }

    public List<PostGetDto>? GetAllPostsByAdmin(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        if(tokenResult.role == "User")
        {
            return null;
        }
        var posts = PostRepository.GetAllPosts();
        var postGetDtos = new List<PostGetDto>();
        foreach (var post in posts)
        {
            var postGetDto = new PostGetDto()
            {
                PostId = post.PostId,
                UserId = post.UserId,
                Title = post.Title,
                Content = post.Content,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };
            postGetDtos.Add(postGetDto);
        }
        return postGetDtos;
    }

    public PostGetDto? GetPostById(Guid postId)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePost(Guid postId, PostCreateDto postCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));
        if(userBlocked == true)
        {
            return false;
        }
        var posts = PostRepository.GetAllPosts();

        foreach (var post in posts)
        {
            if(post.PostId == postId && post.UserId.ToString() == tokenResult.userId)
            {
                post.Title = postCreateDto.Title;
                post.Content = postCreateDto.Content;
                post.UpdatedTime = DateTime.Now;
                PostRepository.SaveAllPosts(posts);
                return true;
            }
        }
        return false;
    }
}
