using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Services.UsersService;

public interface IUsersService
{
    Task<UsersEntity?> GetUserByUsername(string username);
}
