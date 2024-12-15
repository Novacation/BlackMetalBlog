using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Models.ViewModels.Posts;

public class MyPostsResponseViewModel
{
    public required List<PostsEntity> UserPosts { get; init; }
}
