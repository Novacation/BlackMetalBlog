using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Posts;
using Dapper;

namespace BlackMetalBlog.Repositories.Posts;

public class PostsRepository(DapperDbConnectionFactory dbConnectionFactory) : IPostsRepository
{
    public async Task CreatePost(CreatePostDto createPostDto)
    {
        using var conn = await dbConnectionFactory.CreateConnectionAsync();

        const string sql = "insert into Posts (UserId, Title, Content) values (@UserId, @Title, @Content)";

        await conn.ExecuteAsync(sql, createPostDto);
    }
}
