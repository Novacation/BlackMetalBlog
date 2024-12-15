using BlackMetalBlog.Data;
using BlackMetalBlog.Dtos.Posts;
using BlackMetalBlog.Models.Entities;
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

    public async Task<List<PostsEntity>> GetPostsByUserId(int userId, int offset, int pageSize)
    {
        using var conn = await dbConnectionFactory.CreateConnectionAsync();
        const string sql =
            "select * from Posts where UserId = @UserId order by CreatedAt desc offset @Offset rows fetch next @PageSize rows only";

        var posts = await conn.QueryAsync<PostsEntity>(sql,
            new { UserId = userId, Offset = offset, PageSize = pageSize });

        return posts.ToList();
    }
}
