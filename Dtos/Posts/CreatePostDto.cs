using System.ComponentModel.DataAnnotations;

namespace BlackMetalBlog.Dtos.Posts;

public class CreatePostDto
{
    [Required] public int UserId { get; set; }

    [Required]
    [Length(1, 100, ErrorMessage = "Title should be 1-100 characters long.")]
    public string Title { get; set; }

    [Required] public string Content { get; set; }

    [Required] public string PlaylistId { get; set; }
}
