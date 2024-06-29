public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>();

    public User GetUser(string username) => _users.FirstOrDefault(u => u.Username == username);

    public void CreateUser(User user) => _users.Add(user);

    public void ChangePassword(string username, string newPasswordHash)
    {
        var user = GetUser(username);
        if (user != null)
        {
            user.PasswordHash = newPasswordHash;
        }
    }
}
