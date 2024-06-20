using BlackMetalBlog.Dtos.Auth;

namespace BlackMetalBlog.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> validateLogin(LoginDto loginDto);
    }
}