using AuthService.Model.DTO;
using AuthService.Model.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class LoginController(ILogger<LoginController> logger, ILoginManager loginManager) : ControllerBase
{
    private readonly ILogger<LoginController> _logger = logger;
    private readonly ILoginManager _loginManager = loginManager;

    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginDto dto)
    {
        _logger.LogInformation($"User {dto.Email} try to login");
        var token = await _loginManager.TryVerifyUser(dto.Email, dto.Password);
        if (token != null)
        {
            _logger.LogInformation($"User {dto.Email} successfully logged in");
            return Ok(new TokenDto(token));
        }
        _logger.LogWarning($"User {dto.Email} failed to login");
        return Unauthorized();
    }
}