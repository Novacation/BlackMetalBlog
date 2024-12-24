namespace BlackMetalBlog.Middlewares;

public class JwtCookieMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Cookies.ContainsKey("JwtToken"))
        {
            var token = context.Request.Cookies["JwtToken"];
            if (!string.IsNullOrEmpty(token)) context.Request.Headers.Append("Authorization", "Bearer " + token);
        }

        await next(context);
    }
}
