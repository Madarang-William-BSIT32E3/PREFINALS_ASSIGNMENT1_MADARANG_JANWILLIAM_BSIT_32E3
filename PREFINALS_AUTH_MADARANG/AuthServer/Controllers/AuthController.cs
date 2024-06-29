using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        _userService.CreateUser(user);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        if (_authService.ValidateUser(user.Username, user.PasswordHash))
        {
            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }
}
