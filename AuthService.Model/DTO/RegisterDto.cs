namespace AuthService.Model.DTO;

public class RegisterDto(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}