using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BlackMetalBlog.Repositories.UsersRepository;

public class UsersRepository(ApplicationDbContext dbContext, IDbConnectionFactory dbConnectionFactory)
    : IUsersRepository
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

    public async Task<List<UsersEntity>> GetUsers(LoginDto loginDto)
    {
        const string sql = "select * from Users where Username=@Username and Password=@Password";

        using var conn = await dbConnectionFactory.CreateConnectionAsync();
        var users = await conn.QueryAsync<UsersEntity>(sql, new
        {
            loginDto.Username, loginDto.Password
        });

        return users.ToList();
    }
}
