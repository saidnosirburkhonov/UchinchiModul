using SocialMedia_Project_.Api.Dtos;

namespace SocialMedia_Project_.Api.Services;

public interface IAuthService
{
    public Guid RegisterUser(UserRegisterDto userRegisterDto);
    public string LoginUser(UserLoginDto userLoginDto);
}