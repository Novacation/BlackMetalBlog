using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models;
using BlackMetalBlog.Repositories.UsersRepository;
using Microsoft.IdentityModel.Tokens;

namespace BlackMetalBlog.Services.AuthService;

public class AuthService(IUsersRepository usersRepository, IConfiguration configuration) : IAuthService
{
    public string GenerateToken(string username, string name)
    {
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);


        //storing some data in the token
        var subject = new ClaimsIdentity([
            new Claim("username", username),
            new Claim("name", name)
        ]);

        var expires = DateTime.UtcNow.AddMinutes(3);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = expires,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return jwtToken;
    }


    public async Task<bool> IsUsernameAvaiable(string username)
    {
        var possibleUser = await usersRepository.GetUserByUsername(username);

        return possibleUser is null;
    }

    public async Task UpdateUserToken(UsersModel user, string token)
    {
        await usersRepository.UpdateUserToken(user, token);
    }

    public async Task CreateUser(RegisterDto registerDto, string jwt)
    {
        await usersRepository.CreateUser(new UsersModel
        {
            Name = registerDto.Name,
            Username = registerDto.Username,
            Password = registerDto.Password,
            Token = jwt
        });
    }

    public async Task<UsersModel?> ValidateLogin(LoginDto loginDto)
    {
        return await usersRepository.GetUserByCredentials(loginDto);
    }
}
