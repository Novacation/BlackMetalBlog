using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Repositories.UsersRepository;

namespace BlackMetalBlog.Services.AuthService
{
    public class AuthService(IUsersRepository usersRepository) : IAuthService
    {
        public async Task<bool> validateLogin(LoginDto loginDto)
        {
            return await usersRepository.GetUserByCredentials(loginDto) is not null;
        }
    }
}