using AuthService.Model.DTO;

namespace AuthService.Model.Interfaces.Manager;

public interface ILoginManager
{
    // if user was found and authenticated, issues a token
    Task<TokenDto?> TryVerifyUser(string email, string password);
}