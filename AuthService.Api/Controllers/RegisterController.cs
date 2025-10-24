using AuthService.Model.DTO;
using AuthService.Model.Interfaces.Manager;
using AuthService.Service.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController(ILogger<RegisterController> logger, IRegisterManager registerManager) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
    {
        registerDto.DeleteBadSymbols();
        logger.LogInformation($"Registering User {registerDto.Email}");
        var isRegister = await registerManager.TryRegisterUser(registerDto.Email, registerDto.Password);
        if (isRegister)
        {
            logger.LogInformation($"User {registerDto.Email} registered successfully");
            return Created();
        }
        logger.LogWarning($"Email {registerDto.Email} is incorrect or already exists");
        return BadRequest("Email is incorrect or already exists");
    }
}