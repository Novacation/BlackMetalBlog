using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models;

namespace BlackMetalBlog.Repositories.UsersRepository;

public interface IUsersRepository
{
    Task<UsersModel?> GetUserByCredentials(LoginDto loginDto);

    Task<UsersModel?> GetUserByUsername(string username);

    Task UpdateUserToken(UsersModel user, string token);

    Task CreateUser(UsersModel user);
}
