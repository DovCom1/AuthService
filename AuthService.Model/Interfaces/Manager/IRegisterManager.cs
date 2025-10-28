namespace AuthService.Model.Interfaces.Manager;

public interface IRegisterManager
{
    Task<bool> TryRegisterUser(string email, string password);
}