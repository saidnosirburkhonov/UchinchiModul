using Dars3._3.Dtos;
using Dars3._3.Entities;
using Dars3._3.Persistance;

namespace Dars3._3.Services;

public class AuthService : IAuthService
{
    public string LoginUser(UserLoginDto userLoginDto)
    {
        foreach (var user in AppDBContext.Users)
        {
            if(user.UserName == userLoginDto.UserName &&
                user.Password == userLoginDto.Password)
            {
                return user.UserId.ToString() + user.UserRole;
            }
        }
        return "User yoki parol xato";
    }



    public Guid RegisterUser(UserRegisterDto userRegisterDto)
    {
        var user = new User()
        {
            UserId = Guid.NewGuid(),
            UserName = userRegisterDto.UserName,
            Password = userRegisterDto.Password,
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            UserRole = "User",
            UserBlocked = false,
            RegisterTime = DateTime.Now,
        };

        AppDBContext.Users.Add(user);
        return user.UserId;
    }
}
