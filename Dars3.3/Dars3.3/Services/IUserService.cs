using Dars3._3.Dtos;

namespace Dars3._3.Services;

public interface IUserService
{
    public List<UserGetDto>? GetAllUsers(string token);
    public bool DeleteUser(Guid userId, string token);
    public bool DeleteUserPost(Guid postId,  string token);
    public bool BlockedUser(Guid userId, string token);
    public bool ChangeRole(Guid userid, string newRole, string token);

}