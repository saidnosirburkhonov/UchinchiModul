using SocialMedia_Project_.Api.Entities;

namespace SocialMedia_Project_.Api.Services;

public interface IUserRepository
{
    public List<User> GetAllUsers();
    public void SaveAllUsers(List<User> users);
    public bool? UserBlocked(Guid userId);

}