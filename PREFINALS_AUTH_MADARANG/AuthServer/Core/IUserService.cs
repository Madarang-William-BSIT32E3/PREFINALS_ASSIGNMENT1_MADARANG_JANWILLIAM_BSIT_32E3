public interface IUserService
{
    User GetUser(string username);
    void CreateUser(User user);
    void ChangePassword(string username, string newPasswordHash);
}
