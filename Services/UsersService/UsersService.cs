﻿using BlackMetalBlog.Models.Entities;
using BlackMetalBlog.Repositories.UsersRepository;

namespace BlackMetalBlog.Services.UsersService;

public class UsersService(IUsersRepository usersRepository) : IUsersService
{
    public async Task<UsersEntity?> GetUserByUsername(string username)
    {
        return await usersRepository.GetUserByUsername(username);
    }
}
