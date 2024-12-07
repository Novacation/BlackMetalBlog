using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models.Entities;
using Dapper;

namespace BlackMetalBlog.Repositories.UsersRepository;

public class UsersRepository(IDbConnectionFactory dbConnectionFactory)
    : IUsersRepository
{
    public async Task<UsersEntity?> GetUserByCredentials(LoginDto loginDto)
    {
        const string sql = "select * from users where Username = @username and Password = @password";
        using var conn = await dbConnectionFactory.CreateConnectionAsync();
        var user = await conn.QueryFirstOrDefaultAsync<UsersEntity>(sql, new
        {
            username = loginDto.Username,
            password = loginDto.Password
        });


        return user;
    }

    public async Task<UsersEntity?> GetUserByUsername(string username)
    {
        const string sql = "select * from users where Username = @username";
        using var conn = await dbConnectionFactory.CreateConnectionAsync();

        return await conn.QueryFirstOrDefaultAsync<UsersEntity>(sql, new
        {
            username
        });
    }

    public async Task UpdateUserToken(UsersEntity user, string? token)
    {
        const string sql = "update Users set Token = @token where Id = @id";

        using var conn = await dbConnectionFactory.CreateConnectionAsync();

        await conn.ExecuteAsync(sql, new
        {
            id = user.Id,
            token
        });
    }

    public async Task CreateUser(UsersEntity user)
    {
        const string sql =
            "insert into Users (Username, Password, Name, RoleCode, Token) values (@username,@password, @name, @roleCode, @token);";

        const string x = "select * from Users";
        using var conn = await dbConnectionFactory.CreateConnectionAsync();

        await conn.ExecuteAsync(sql, new
        {
            username = user.Username,
            password = user.Password,
            name = user.Name,
            roleCode = user.RoleCode,
            token = user.Token
        });
    }
}
