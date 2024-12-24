using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackMetalBlog.Controllers;

[Authorize]
[Route("home")]
public class HomeController(ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    public IActionResult Home()
    {
        var name = User.Claims.FirstOrDefault(item => item.Type.Equals("name"));

        if (name is null) return View();

        ViewData["UserName"] = name.Value;

        return View();
    }
}
