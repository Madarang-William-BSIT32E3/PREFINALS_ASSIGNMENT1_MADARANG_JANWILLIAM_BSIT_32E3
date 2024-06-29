public interface IAuthService
{
    string GenerateToken(User user);
    bool ValidateUser(string username, string password);
}
