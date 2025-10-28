using AuthService.Model.Entities;

namespace AuthService.Model.Interfaces.Service;

public interface IUserService
{
    Task<User?> TryGetUser(string email);
    Task<bool> CreateUser(string email, string password);
}