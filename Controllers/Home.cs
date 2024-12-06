using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackMetalBlog.Controllers;

[Route("home")]
public class HomeController(ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Home()
    {
        var name = User.Claims.FirstOrDefault(item => item.Type.Equals("name"));

        if (name is null) return View();

        ViewData["UserName"] = name.Value;

        return View();
    }
}
