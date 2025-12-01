namespace AuthService.Model.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string HashPassword { get; set; }
}