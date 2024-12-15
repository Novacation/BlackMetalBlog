namespace BlackMetalBlog.Models.Entities;

public class PostsEntity
{
    private readonly string _playlistId;

    public int Id { get; init; }

    public required int UserId { get; init; }

    public required string Title { get; init; }

    public required string Content { get; init; }

    public required string PlaylistId
    {
        get => _playlistId;
        init => _playlistId = value.Length > 42 ? value[..42] : value;
    }

    public required DateTime CreatedAt { get; init; }

    public required DateTime UpdatedAt { get; init; }
}
