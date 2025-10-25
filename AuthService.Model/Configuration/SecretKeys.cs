namespace AuthService.Model.Configuration;

public class SecretKeys
{
    public string TokenSecretKey { get; init; } = null!;
    public string PasswordSecretKey { get; init; } = null!;
}