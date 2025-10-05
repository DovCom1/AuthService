using AuthService.Infrastructure;
using AuthService.Model.Entities;
using AuthService.Model.Interfaces.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AuthService.Service.Service;

public class PostgresUserService(ILogger<PostgresUserService> logger, PostgresDbContext context) : IUserService
{
    private readonly ILogger<PostgresUserService> _logger = logger;
    private PostgresDbContext _context = context;

    public async Task<User?> TryGetUser(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.Username == username);
        return user;
    }

    public async Task<bool> CreateUser(string username, string hashPassword)
    {
        try
        {
            await _context.Users.AddAsync(new User { Username = username,  HashPassword = hashPassword });
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }
}