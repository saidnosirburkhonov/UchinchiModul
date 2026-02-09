using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia_Project_.Api.Dtos;
using SocialMedia_Project_.Api.Services;

namespace SocialMedia_Project_.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController()
        {
            UserService = new UserService();
        }

        [HttpGet("get-all")]
        public List<UserGetDto>? GetAll(string token)
        {
            return UserService.GetAllUsers(token);
        }

        [HttpDelete("delete")]
        public bool DeleteUser(Guid userId, string token)
        {
            return UserService.DeleteUser(userId, token);
        }

        [HttpDelete("delete-user-post")]
        public bool DeleteUserPost(Guid postId,  string token)
        {
            return UserService.DeleteUserPost(postId, token);
        }

        [HttpPut("block")]
        public bool BlockUser(Guid userId, string token)
        {
            return UserService.BlockUser(userId, token);
        }

        [HttpPut("change-role")]
        public bool ChangeRole(Guid userId, string newRole, string token)
        {
            return UserService.ChangeRole(userId, newRole, token);
        }

    }
}
