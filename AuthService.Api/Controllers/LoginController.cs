using AuthService.Model.DTO;
using AuthService.Model.Interfaces.Manager;
using AuthService.Service.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class LoginController(ILogger<LoginController> logger, ILoginManager loginManager) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> LoginUser([FromBody] LoginDto dto)
    {
        dto.DeleteBadSymbols();
        logger.LogInformation($"User {dto.Email} try to login");
        var tokenDto = await loginManager.TryVerifyUser(dto.Email, dto.Password);
        if (tokenDto != null)
        {
            logger.LogInformation($"User {dto.Email} successfully logged in");
            return Ok(tokenDto);
        }
        logger.LogWarning($"User {dto.Email} failed to login");
        return Unauthorized();
    }
}