using Dars3._3.Dtos;
using Dars3._3.Persistance;

namespace Dars3._3.Services;

public class UserService : IUserService
{
    private readonly string UsersPath;
    public UserService()
    {
        UsersPath = "D:\\Coding\\DotNet\\UchinchiModul\\Dars3.3\\Dars3.3\\DataBase\\UsersDB.json";
    }

    public bool BlockedUser(Guid userId, string token)
    {
        var tokenResult = AppDBContext.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        foreach (var user in AppDBContext.Users)
        {
            if (user.UserId == userId)
            {
                user.UserBlocked = !user.UserBlocked;
                return true;
            }
        }

        return false;
    }

    public bool ChangeRole(Guid userId, string newRole, string token)
    {
        var tokenResult = AppDBContext.GetTokenInfo(token);

        if (tokenResult.role != "SuperAdmin")
        {
            return false;
        }

        foreach (var user in AppDBContext.Users)
        {
            if (user.UserId == userId)
            {
                user.UserRole = newRole;
                return true;
            }
        }

        return false;
    }

    public bool DeleteUser(Guid userId, string token)
    {
        var tokenResult = AppDBContext.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        foreach (var user in AppDBContext.Users)
        {
            if (user.UserId == userId)
            {
                AppDBContext.Users.Remove(user);
                return true;
            }
        }

        return false;
    }

    public bool DeleteUserPost(Guid postId, string token)
    {
        var tokenResult = AppDBContext.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        foreach (var post in AppDBContext.Posts)
        {
            if (post.PostId == postId)
            {
                AppDBContext.Posts.Remove(post);
                return true;
            }
        }

        return false;
    }

    public List<UserGetDto>? GetAllUsers(string token)
    {
        var tokenResult = AppDBContext.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return null;
        }

        var users = AppDBContext.Users;
        var userDtos = new List<UserGetDto>();
        foreach (var user in users)
        {
            var userDto = new UserGetDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                UserRole = user.UserRole,
                UserBlocked = user.UserBlocked,
                RegisterTime = user.RegisterTime
            };
            userDtos.Add(userDto);
        }

        return userDtos;
    }
}
