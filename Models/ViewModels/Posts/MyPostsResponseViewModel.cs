using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Models.ViewModels.Posts;

public class MyPostsResponseViewModel
{
    public required int UserId { get; init; }
    public required List<PostsEntity> UserPosts { get; init; }
}
