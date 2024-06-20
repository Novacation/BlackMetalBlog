using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace BlackMetalBlog.Controllers
{
    [Route("auth")]
    public class AuthController(IAuthService authService) : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            Console.WriteLine(HttpContext.Session.GetString("IsUserLoggedIn"));
            if (HttpContext.Session.GetString("IsUserLoggedIn") != "true")
            {
                return View();
            }

            return RedirectToPage("/Home/MyBands");

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            var isLoginValid = await authService.validateLogin(loginDto);
            if (!isLoginValid) return View();

            HttpContext.Session.SetString("IsUserLoggedIn", "true");

            return RedirectToPage("/Home/MyBands");
        }


        [HttpGet("register")]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("IsUserLoggedIn") != "true")
            {
                return View();
            }

            return RedirectToPage("/Home/MyBands");
        }
    }
}