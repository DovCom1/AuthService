namespace AuthService.Model.Interfaces.Manager;

public interface ILoginManager
{
    // if user was found and authenticated, issues a token
    Task<string?> TryVerifyUser(string username, string password);
}