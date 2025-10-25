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
    public async Task<string?> TryVerifyUser(string email, string password)
    {
        logger.LogInformation($"Try search user {email} in storage");
        var user = await userService.TryGetUser(email);
        if (user != null && passwordService.VerifyUser(user.HashPassword, password))
        {
            logger.LogInformation($"User {email} was found and authenticated");
            return tokenService.GenerateToken(email);
        }
        logger.LogWarning($"User {email} was not found or password is incorrect");
        return null;
    }
}