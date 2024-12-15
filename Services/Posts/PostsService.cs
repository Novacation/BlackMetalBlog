using BlackMetalBlog.Dtos.Posts;
using BlackMetalBlog.Models.Entities;
using BlackMetalBlog.Repositories.Posts;

namespace BlackMetalBlog.Services.Posts;

public class PostsService(IPostsRepository postsRepository) : IPostsService
{
    public async Task CreatePost(CreatePostDto createPostDto)
    {
        await postsRepository.CreatePost(createPostDto);
    }

    public async Task<List<PostsEntity>> GetPostsByUserId(int userId, int offset, int pageSize)
    {
        return await postsRepository.GetPostsByUserId(userId, offset, pageSize);
    }
}
