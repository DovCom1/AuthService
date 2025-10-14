using AuthService.Infrastructure;
using AuthService.Model.Interfaces.Manager;
using AuthService.Model.Interfaces.Service;
using AuthService.Service.Manager;
using AuthService.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Service.DependencyInjection;

public static class DependencyExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfigurationManager configuration)
    {
        return services
            .AddStorage(configuration)
            .AddServices()
            .AddManagers();
    }
    private static IServiceCollection AddStorage(
        this IServiceCollection services, 
        IConfigurationManager configuration)
    {
        return services.AddDbContext<PostgresDbContext>(options =>
            options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]));
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        
        return services
            .AddLogging()
            .AddScoped<IUserService, PostgresUserService>()
            .AddSingleton<ITokenService, TokenService>()
            .AddSingleton<IPasswordService, PasswordService>();
    }

    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        return services
            .AddScoped<ILoginManager, LoginManager>()
            .AddScoped<IRegisterManager, RegisterManager>();
    }
}