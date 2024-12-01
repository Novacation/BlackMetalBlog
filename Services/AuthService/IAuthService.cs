using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models;

namespace BlackMetalBlog.Services.AuthService;

public interface IAuthService
{
    Task<UsersModel?> ValidateLogin(LoginDto loginDto);

    Task<bool> IsUsernameAvaiable(string username);

    string GenerateToken(string username, string name);

    Task UpdateUserToken(UsersModel user, string token);

    Task CreateUser(RegisterDto registerDto, string jwt);
}
