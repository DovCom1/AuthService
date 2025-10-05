using AuthService.Model.Configuration;
using AuthService.Service.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<SecretKeys>(builder.Configuration.GetSection("SecretKeys"));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();