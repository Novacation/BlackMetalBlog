using BlackMetalBlog.Dtos.Posts;
using BlackMetalBlog.Models.Entities;

namespace BlackMetalBlog.Repositories.Posts;

public interface IPostsRepository
{
    Task CreatePost(CreatePostDto createPostDto);

    Task<List<PostsEntity>> GetPostsByUserId(int userId, int offset, int pageSize);

    Task<PostsEntity?> GetPostById(int postId);
}
