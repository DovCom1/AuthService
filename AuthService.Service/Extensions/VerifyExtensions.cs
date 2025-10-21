using AuthService.Model.DTO;

namespace AuthService.Service.Extensions;

public static class VerifyExtensions
{
    public static string DeleteBadSymbols(this string name) => name.Replace(Environment.NewLine, "");

    public static void DeleteBadSymbols(this LoginDto dto)
    {
        dto.Email = dto.Email.DeleteBadSymbols();
        dto.Password = dto.Password.DeleteBadSymbols();
    }

    public static void DeleteBadSymbols(this RegisterDto dto)
    {
        dto.Email = dto.Email.DeleteBadSymbols();
        dto.Password = dto.Password.DeleteBadSymbols();
    }
}