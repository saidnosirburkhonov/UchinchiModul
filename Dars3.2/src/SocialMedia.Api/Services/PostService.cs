using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;
using System.Text.Json;

namespace SocialMedia.Api.Services;

public class PostService : IPostService
{
    private List<Post> Posts;
    private readonly string FilePath;
    public PostService()
    {
        FilePath = "D:\\Coding\\DotNet\\UchinchiModul\\Dars3.2\\src\\SocialMedia.Api\\AppDBContext\\Data.json";
        Posts = new List<Post>();
    }

    public Guid CreatePost(PostCreateDto postCreateDto)
    {
        ReadPostFromFile();
        Post post = new Post()
        {
            PostId = Guid.NewGuid(),
            Title = postCreateDto.Title,
            Content = postCreateDto.Content,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            UserId = postCreateDto.UserId,
        };
        Posts.Add(post);
        SavePostToFile();
        return post.PostId;
    }

    public bool DeletePost(Guid postId)
    {
        ReadPostFromFile();
        foreach (var post in Posts)
        {
            if(post.PostId == postId)
            {
                Posts.Remove(post);
                SavePostToFile() ;
                return true;
            }
        }
        return false;
    }

    public List<PostGetDto> GetAllPosts()
    {
        ReadPostFromFile() ;
        List<PostGetDto> postGetDtos = new List<PostGetDto>();
        foreach (var p in Posts)
        {
            postGetDtos.Add(new PostGetDto()
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedDate,
                UpdatedAt = p.UpdatedDate,
                UserId = p.UserId,
            });
        }
        return postGetDtos ;
    }

    public PostGetDto? GetPostById(Guid postId)
    {
        ReadPostFromFile();
        foreach (var p in Posts)
        {
            if(p.PostId == postId)
            {
                return new PostGetDto()
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedDate,
                    UpdatedAt = p.UpdatedDate,
                    UserId = p.UserId,
                };

            }
        }
        return null;
    }

    public bool UpdatePost(Guid postId, PostUpdateDto postUpdateDto)
    {
        ReadPostFromFile();
        foreach (var p in Posts)
        {
            if(p.PostId == postId)
            {
                p.Title = postUpdateDto.Title;
                p.Content = postUpdateDto.Content;
                p.UpdatedDate = DateTime.Now;
                SavePostToFile();
                return true;
            }
        }
        return false;
    }

    private void SavePostToFile()
    {
        var json = JsonSerializer.Serialize(Posts);
        File.WriteAllText("NewData.json", json);
    }
    private void ReadPostFromFile()
    {
        var json = File.ReadAllText(FilePath);
        if (string.IsNullOrEmpty(json))
        {
            Posts = new List<Post>();
            return;
        }

        Posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
    }

}
