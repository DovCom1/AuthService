namespace AuthService.Model.Interfaces.Service;

public interface ITokenService
{
    string GenerateToken(string username);
}