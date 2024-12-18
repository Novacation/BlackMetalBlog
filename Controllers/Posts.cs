using BlackMetalBlog.Models.ViewModels.Posts;
using BlackMetalBlog.Services.Posts;
using BlackMetalBlog.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackMetalBlog.Controllers;

[Authorize]
[Route("posts")]
public class Posts(IPostsService postsService, IUsersService usersService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> MyPosts()
    {
        var username = User.Claims.FirstOrDefault(item => item.Type.Equals("username"))!.Value;

        var user = await usersService.GetUserByUsername(username);

        var posts = await postsService.GetPostsByUserId(user!.Id, 0, 10);

        ViewData["UserName"] = user.Name;

        return View("Posts", new MyPostsResponseViewModel
        {
            UserPosts = posts
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> PostById(int id)
    {
        var name = User.Claims.FirstOrDefault(item => item.Type.Equals("name"))!.Value;

        var post = await postsService.GetPostById(id);

        ViewData["UserName"] = name;

        return View("PostById", post);
    }
}
