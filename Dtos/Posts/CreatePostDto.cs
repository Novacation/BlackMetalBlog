using System.ComponentModel.DataAnnotations;

namespace BlackMetalBlog.Dtos.Posts;

public class CreatePostDto
{
    [Required(ErrorMessage = "Error while sending post")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Missing Title")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Title should be 1-100 characters long.")]
    public required string Title { get; set; }

    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [StringLength(maximumLength: 100, ErrorMessage = "Content should be 1-5000 characters long.")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Missing Spotify Playlist Id")]
    public required string PlaylistId { get; set; }
}
