using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackMetalBlog.Models.Entities;

[Table("Users")]
public class UsersEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string Name { get; init; }

    public string RoleCode { get; init; } = "default_user";

    public string? Token { get; set; }
}