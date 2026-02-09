using Dars3._3.Dtos;

namespace Dars3._3.Services;

public interface IAuthService
{
    public Guid RegisterUser(UserRegisterDto userRegisterDto);
    public string LoginUser(UserLoginDto userLoginDto);
}