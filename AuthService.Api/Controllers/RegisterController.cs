using AuthService.Model.DTO;
using AuthService.Model.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController(ILogger<RegisterController> logger, IRegisterManager registerManager) : ControllerBase
{
    private readonly ILogger<RegisterController> _logger = logger;
    private readonly IRegisterManager _registerManager = registerManager;

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
    {
        _logger.LogInformation($"Registering User {registerDto.Email}");
        var isRegister = await _registerManager.TryRegisterUser(registerDto.Email, registerDto.Password);
        if (isRegister)
        {
            _logger.LogInformation($"User {registerDto.Email} registered successfully");
            return Ok();
        }
        _logger.LogWarning($"Email {registerDto.Email} is incorrect or already exists");
        return BadRequest("Email is incorrect or already exists");
    }
}