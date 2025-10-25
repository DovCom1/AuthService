using AuthService.Model.Interfaces.Manager;
using AuthService.Model.Interfaces.Service;
using Microsoft.Extensions.Logging;

namespace AuthService.Service.Manager;

public class RegisterManager(
    ILogger<RegisterManager> logger,
    IUserService userService,
    IPasswordService passwordService) : IRegisterManager
{
    public async Task<bool> TryRegisterUser(string email, string password)
    {
        var user = await userService.TryGetUser(email);
        if (user == null)
        {
            logger.LogInformation($"User {email} can be added");
            return await userService.CreateUser(email, passwordService.HashPassword(password));
        }
        return false;
    }
}