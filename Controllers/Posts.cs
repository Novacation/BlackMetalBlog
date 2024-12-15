using BlackMetalBlog.Models.ViewModels.Posts;
using BlackMetalBlog.Repositories.Posts;
using BlackMetalBlog.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackMetalBlog.Controllers;

[Authorize]
[Route("posts")]
public class Posts(IPostsRepository postsRepository, IUsersRepository usersRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> MyPosts()
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"]!;

        var username = User.Claims.FirstOrDefault(item => item.Type.Equals("username"))!.Value;

        var user = await usersRepository.GetUserByUsername(username);

        var posts = await postsRepository.GetPostsByUserId(user!.Id, 0, 10);

        ViewData["UserName"] = user.Name;

        return View("Posts", new MyPostsResponseViewModel
        {
            UserPosts = posts
        });
    }
}
