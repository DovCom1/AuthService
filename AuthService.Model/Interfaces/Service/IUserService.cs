using AuthService.Model.Entities;

namespace AuthService.Model.Interfaces.Service;

public interface IUserService
{
    Task<User?> TryGetUser(string username);
    Task<bool> CreateUser(string username, string password);
}