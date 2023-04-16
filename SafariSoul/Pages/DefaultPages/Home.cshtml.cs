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
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
                {
                    HttpContext.Session.SetString(SessionKeyName, "Default");            //needs to set the session user to default every time this page is loaded
                }     
                var name = HttpContext.Session.GetString(SessionKeyName);

                _logger.LogInformation("Session Name: {Name}", name);
            }
        }
    }
}
