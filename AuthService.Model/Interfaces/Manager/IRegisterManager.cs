using AuthService.Model.DTO;

namespace AuthService.Model.Interfaces.Manager;

public interface IRegisterManager
{
    Task<bool> TryRegisterUser(string email, string password);
    Task<bool> TryPutUserId(UserIdDto userId);
}