using BlackMetalBlog.Dtos.Posts;
using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Services.Posts;

public interface IPostsService
{
    Task CreatePost(CreatePostDto createPostDto);

    Task<List<PostsEntity>> GetPostsByUserId(int userId, int offset, int pageSize);
}
