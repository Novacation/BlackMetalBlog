using BlackMetalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackMetalBlog.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<UsersModel> UsersModel { get; set; }

    }
}
