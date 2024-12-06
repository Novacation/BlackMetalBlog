using BlackMetalBlog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackMetalBlog.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<UsersEntity> UsersModel { get; set; }
}