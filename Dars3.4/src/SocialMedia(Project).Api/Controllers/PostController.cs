using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia_Project_.Api.Dtos;
using SocialMedia_Project_.Api.Services;

namespace SocialMedia_Project_.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService PostService;
        public PostController()
        {
             PostService = new PostService();
        }
        [HttpPost("add")]
        public Guid Create(PostCreateDto postCreateDto, string token)
        {
            return PostService.AddPost(postCreateDto, token);
        }

        [HttpGet("get-all")]
        public List<PostGetDto> GetAll(string token)
        {
            return PostService.GetAllPosts(token);
        }

        [HttpGet("get-all-by-admin")]
        public List<PostGetDto>? GetAllByAdmin(string token)
        {
            return PostService.GetAllPostsByAdmin(token);
        }

        [HttpGet("get-by-id")]
        public PostGetDto? GetById(Guid postId)
        {
            return PostService.GetPostById(postId);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid postId, string token)
        {
            return PostService.DeletePost(postId, token);
        }

        [HttpPut("update")]
        public bool Update(Guid postId, PostCreateDto postCreateDto, string token)
        {
            return PostService.UpdatePost(postId, postCreateDto, token);
        }

    }
}
