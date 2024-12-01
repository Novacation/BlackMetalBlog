using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackMetalBlog.Pages.FavoriteBands
{
    public class FavoriteBands(ILogger<FavoriteBands> logger) : PageModel
    {
        private readonly ILogger<FavoriteBands> _logger = logger;

        public void OnGet()
        {
        }

        public void TestLog()
        {
            Console.WriteLine("TESTING");
        }
    }
}
