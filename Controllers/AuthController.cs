using BlackMetalBlog.Dtos.Auth;
using BlackMetalBlog.Services.AuthService;
using BlackMetalBlog.Services.UsersService;
using Microsoft.AspNetCore.Mvc;

namespace BlackMetalBlog.Controllers;

[Route("auth")]
public class AuthController(IAuthService authService, IUsersService usersService)
    : Controller
{
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        // Check if the user is authenticated and returns the view so he can log in
        if (User.Identity is { IsAuthenticated: false }) return View("Login/Login");

        var jwtToken = HttpContext.Request.Cookies["JwtToken"];

        if (jwtToken is null) return View("Login/Login");

        var username = User.Claims.FirstOrDefault(item => item.Type.Equals("username"))!.Value;

        var user = await usersService.GetUserByUsername(username);

        if (user is null) return View("Login/Login");

        //checks if the cookie's token is the same as the user's db tuple token
        if (!jwtToken.Equals(user.Token)) return View("Login/Login");

        var name = User.Claims.FirstOrDefault(item => item.Type.Equals("name"))!.Value;

        ViewData["UserName"] = name;

        // If authenticated, redirect to the home page
        return RedirectToAction("Home", "Home");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
    {
        var possibleUser = await authService.ValidateLogin(loginDto);
        if (possibleUser is null)
        {
            ViewData["ErrorMessage"] = "Invalid credentials";

            return View("Login/Login");
        }

        var generatedToken = authService.GenerateToken(loginDto.Username, possibleUser.Name);
        await authService.UpdateUserToken(possibleUser, generatedToken);

        Response.Cookies.Append("JwtToken", generatedToken, new CookieOptions
        {
            HttpOnly = true, // Prevent JavaScript from accessing the cookie
            Secure = false, // Ensure the cookie is sent over HTTPS only
            SameSite = SameSiteMode.Strict, // Prevent the cookie from being sent with cross-site requests
            Expires = DateTimeOffset.UtcNow.AddYears(5)
        });
        ViewData["UserName"] = possibleUser.Name;


        return RedirectToAction("Home", "Home");
    }


    [HttpGet("register")]
    public async Task<IActionResult> Register()
    {
        if (User.Identity is { IsAuthenticated: false }) return View("Register/Register");

        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        if (jwtToken is null) return View("Register/Register");

        var username = User.Claims.FirstOrDefault(item => item.Type.Equals("username"))!.Value;

        var user = await usersService.GetUserByUsername(username);

        if (user is null) return View("Register/Register");

        //checks if the cookie's token is the same as the user's db tuple token
        if (!jwtToken.Equals(user.Token)) return View("Register/Register");

        var name = User.Claims.FirstOrDefault(item => item.Type.Equals("name"))!.Value;

        ViewData["UserName"] = name;

        // If authenticated, redirect to the home page
        return RedirectToAction("Home", "Home");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
    {
        var isUsernameAvaiable = await authService.IsUsernameAvaiable(registerDto.Username);

        ViewData["ErrorMessage"] = "Username not avaiable";

        if (!isUsernameAvaiable) return RedirectToAction("Register");
        var jwt = authService.GenerateToken(registerDto.Username, registerDto.Name);

        await authService.CreateUser(registerDto, jwt);

        Response.Cookies.Append("JwtToken", jwt, new CookieOptions
        {
            HttpOnly = true, // Prevent JavaScript from accessing the cookie
            Secure = false, // Ensure the cookie is sent over HTTPS only
            SameSite = SameSiteMode.Strict, // Prevent the cookie from being sent with cross-site requests
            Expires = DateTimeOffset.UtcNow.AddYears(5)
        });

        ViewData["UserName"] = registerDto.Name;

        return RedirectToAction("Home", "Home");
    }

    [HttpPost("logoff")]
    public async Task<IActionResult> Logoff()
    {
        var username = User.Claims.FirstOrDefault(item => item.Type.Equals("username"));

        var user = await usersService.GetUserByUsername(username!.Value);

        if (user is not null) await authService.UpdateUserToken(user, null);
        Response.Cookies.Delete("JwtToken");

        return RedirectToActionPermanent("Login");
    }
}
