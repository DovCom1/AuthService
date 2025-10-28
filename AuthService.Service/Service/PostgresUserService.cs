using AuthService.Infrastructure;
using AuthService.Model.Entities;
using AuthService.Model.Interfaces.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AuthService.Service.Service;

public class PostgresUserService(ILogger<PostgresUserService> logger, PostgresDbContext context) : IUserService
{
    public async Task<User?> TryGetUser(string email)
    {
        return await context.Users.FirstOrDefaultAsync(
            u => u.Email == email);
    }

    public async Task<bool> CreateUser(string email, string hashPassword)
    {
        try
        {
            await context.Users.AddAsync(new User { Email = email,  HashPassword = hashPassword });
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return false;
        }
    }
}