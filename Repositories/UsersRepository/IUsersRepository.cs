using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Repositories.UsersRepository;

public interface IUsersRepository
{
    Task<UsersEntity?> GetUserByCredentials(LoginDto loginDto);

    Task<UsersEntity?> GetUserByUsername(string username);

    Task UpdateUserToken(UsersEntity user, string? token);

    Task CreateUser(UsersEntity user);
}
