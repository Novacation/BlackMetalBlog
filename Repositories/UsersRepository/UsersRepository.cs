using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackMetalBlog.Repositories.UsersRepository;

public class UsersRepository(ApplicationDbContext dbContext) : IUsersRepository
{
    public async Task<UsersEntity?> GetUserByCredentials(LoginDto loginDto)
    {
        return await dbContext.UsersModel.FirstOrDefaultAsync(user =>
            user.Username == loginDto.Username && user.Password == loginDto.Password);
    }

    public async Task<UsersEntity?> GetUserByUsername(string username)
    {
        return await dbContext.UsersModel.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task UpdateUserToken(UsersEntity user, string? token)
    {
        user.Token = token;

        await dbContext.SaveChangesAsync();
    }

    public async Task CreateUser(UsersEntity user)
    {
        await dbContext.UsersModel.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}
