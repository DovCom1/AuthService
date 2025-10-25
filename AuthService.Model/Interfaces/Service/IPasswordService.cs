namespace AuthService.Model.Interfaces.Service;

public interface IPasswordService
{
    // true if hash password is Equal hashPassword
    bool VerifyUser(string hashPassword, string password);
    string HashPassword(string password);
}