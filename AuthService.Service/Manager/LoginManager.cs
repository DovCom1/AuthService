using AuthService.Model.Interfaces.Manager;
using AuthService.Model.Interfaces.Service;
using Microsoft.Extensions.Logging;

namespace AuthService.Service.Manager;

public class LoginManager(
    IUserService userService, 
    IPasswordService passwordService, 
    ITokenService tokenService,
    ILogger<LoginManager> logger) : ILoginManager
{
    private readonly ILogger<LoginManager> _logger = logger;
    private readonly IUserService _userService = userService;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly ITokenService _tokenService = tokenService;
    
    public async Task<string?> TryVerifyUser(string username, string password)
    {
        _logger.LogInformation($"Try search user {username} in storage");
        var user = await _userService.TryGetUser(username);
        if (user != null && _passwordService.VerifyUser(user.HashPassword, password))
        {
            _logger.LogInformation($"User {username} was found and authenticated");
            return _tokenService.GenerateToken(username);
        }
        _logger.LogWarning($"User {username} was not found or password is incorrect");
        return null;
    }
}