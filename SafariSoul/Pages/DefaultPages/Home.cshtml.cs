using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SafariSoul.Pages.DefaultPages
{
    public class Home
    {
        public class HomeModel : PageModel
        {
            public const string SessionKeyName = "_Name";

            private readonly ILogger<PageModel> _logger;

            public HomeModel(ILogger<PageModel> logger)
            {
                _logger = logger;
            }
            public void OnGet()
            {
                HttpContext.Session.SetString(SessionKeyName, "Default");
                var name = HttpContext.Session.GetString(SessionKeyName);

                _logger.LogInformation("Session Name: {Name}", name);
            }
        }
    }
}
