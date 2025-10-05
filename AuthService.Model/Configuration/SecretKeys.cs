namespace AuthService.Model.Configuration;

public class SecretKeys
{
    public string TokenSecretKey { get; set; } = default!;
    public string PasswordSecretKey { get; set; } = default!;
}