using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackMetalBlog.Repositories.UsersRepository;

public class UsersRepository(ApplicationDbContext dbContext) : IUsersRepository
{
    public async Task<UsersModel?> GetUserByCredentials(LoginDto loginDto)
    {
        return await dbContext.UsersModel.FirstOrDefaultAsync(user =>
            user.Username == loginDto.Username && user.Password == loginDto.Password);
    }

    public async Task<UsersModel?> GetUserByUsername(string username)
    {
        return await dbContext.UsersModel.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task UpdateUserToken(UsersModel user, string token)
    {
        user.Token = token;

        await dbContext.SaveChangesAsync();
    }

    public async Task CreateUser(UsersModel user)
    {
        await dbContext.UsersModel.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}
