using BlackMetalBlog.Dtos.Posts;

namespace BlackMetalBlog.Repositories.Posts;

public interface IPostsRepository
{
    Task CreatePost(CreatePostDto createPostDto);
}
