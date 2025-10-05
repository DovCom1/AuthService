using AuthService.Model.Interfaces.Manager;
using AuthService.Model.Interfaces.Service;
using Microsoft.Extensions.Logging;

namespace AuthService.Service.Manager;

public class RegisterManager(
    ILogger<RegisterManager> logger,
    IUserService userService,
    IPasswordService passwordService) : IRegisterManager
{
    private readonly ILogger<RegisterManager> _logger = logger;
    private readonly IUserService _userService = userService;
    private readonly IPasswordService _passwordService = passwordService;
    
    public async Task<bool> TryRegisterUser(string username, string password)
    {
        var user = await _userService.TryGetUser(username);
        if (user == null)
        {
            _logger.LogInformation($"User {username} can be added");
            return await _userService.CreateUser(username, _passwordService.HashPassword(password));
        }
        return false;
    }
}