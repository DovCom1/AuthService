using AuthService.Model.Configuration;
using AuthService.Service.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<SecretKeys>(builder.Configuration.GetSection("SecretKeys"));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();