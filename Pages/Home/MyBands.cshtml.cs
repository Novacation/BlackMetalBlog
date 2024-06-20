using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackMetalBlog.Pages.Home
{
    public class MyBands : PageModel
    {
        private readonly ILogger<MyBands> _logger;

        public MyBands(ILogger<MyBands> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}