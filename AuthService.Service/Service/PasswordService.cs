using AuthService.Model.Configuration;
using AuthService.Model.Interfaces.Service;
using Microsoft.Extensions.Options;

namespace AuthService.Service.Service;

public class PasswordService(IOptions<SecretKeys> options) : IPasswordService
{
    private readonly string _secretKey = options.Value.PasswordSecretKey;
    public bool VerifyUser(string hashPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(_secretKey + password, hashPassword);
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(_secretKey + password);
    }
}