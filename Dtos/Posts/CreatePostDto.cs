using System.ComponentModel.DataAnnotations;

namespace BlackMetalBlog.Dtos.Posts;

public class CreatePostDto
{
    [Required] public int UserId { get; set; }

    [Required]
    [Length(1, 100, ErrorMessage = "Title should be 1-100 characters long.")]
    public required string Title { get; set; }

    [Required]
    [Length(1, 100, ErrorMessage = "Content should be max 5000 characters long.")]
    public required string Content { get; set; }

    [Required] public required string PlaylistId { get; set; }
}
