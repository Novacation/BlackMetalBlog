using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models;

namespace BlackMetalBlog.Repositories.UsersRepository
{
    public interface IUsersRepository
    {
        Task<UsersModel?> GetUserByCredentials(LoginDto loginDto);
    }
}