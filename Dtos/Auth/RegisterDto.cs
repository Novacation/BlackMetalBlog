using System.ComponentModel.DataAnnotations;

namespace BlackMetalBlog.Dtos.Auth;

public class RegisterDto
{
    [MaxLength(100)] public required string Name { get; init; }

    [MaxLength(20)] public required string Username { get; init; }

    [MaxLength(20)] public required string Password { get; init; }
}
