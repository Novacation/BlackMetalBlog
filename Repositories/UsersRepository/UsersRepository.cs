using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackMetalBlog.Repositories.UsersRepository
{
    public class UsersRepository(ApplicationDbContext applicationDb) : IUsersRepository
    {
        public async Task<UsersModel?> GetUserByCredentials(LoginDto loginDto)
        {
            return await applicationDb.UsersModel.FirstOrDefaultAsync(user => user.Username == loginDto.Username && user.Password == loginDto.Password);
        }
    }
}