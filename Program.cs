using System.Text;
using BlackMetalBlog.Data;
using BlackMetalBlog.Middlewares;
using BlackMetalBlog.Repositories.UsersRepository;
using BlackMetalBlog.Services.AuthService;
using BlackMetalBlog.Services.UsersService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddSingleton<IDbConnectionFactory>(new DapperDbConnectionFactory(connectionString));

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };

    o.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            // Skip the default behavior of returning a 401 Unauthorized response
            context.HandleResponse();

            // Redirect to the login page
            context.Response.Redirect("/auth/login");
            return Task.CompletedTask;
        }
    };
});

// Add configuration from appsettings.json
if (builder.Environment.IsDevelopment())
    builder.Configuration.AddJsonFile("appsettings.Development.json", false, true)
        .AddEnvironmentVariables();
else
    builder.Configuration.AddJsonFile("appsettings.Production.json", false, true)
        .AddEnvironmentVariables();


builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();


builder.Logging.ClearProviders(); // Optionally clear default logging providers
builder.Logging.AddConsole(); // Add console logging
builder.Logging.AddDebug(); // Add debug logging

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

if (!app.Environment.IsDevelopment())
    // Disable HTTPS redirection in Docker/Production
    app.UseHsts();
else
    app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<JwtCookieMiddleware>();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.MapRazorPages();

app.Run();
