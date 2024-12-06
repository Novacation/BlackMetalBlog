using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Services.AuthService;

public interface IAuthService
{
    Task<UsersEntity?> ValidateLogin(LoginDto loginDto);

    Task<bool> IsUsernameAvaiable(string username);

    string GenerateToken(string username, string name);

    Task UpdateUserToken(UsersEntity user, string? token);

    Task CreateUser(RegisterDto registerDto, string jwt);
}
