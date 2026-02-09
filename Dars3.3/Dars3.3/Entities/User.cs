namespace Dars3._3.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Password { get; set; }
    public string UserRole { get; set; }
    public bool UserBlocked { get; set; }
    public DateTime RegisterTime { get; set; }
}
