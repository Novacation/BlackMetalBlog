using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Services.Users;

public interface IUsersService
{
    Task<UsersEntity?> GetUserByUsername(string username);
}