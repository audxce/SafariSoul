using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SafariSoul.Pages.Login
{
    /*public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
    }*/

    public class LoginModel : PageModel
    {
        public const string SessionKeyName = "_Name";

        private readonly ILogger<PageModel> _logger;

        public LoginModel(ILogger<PageModel> logger)
        {
            _logger = logger;
        }

        public async Task OnPost()
        {
            var username = Request.Form["Username"];

            if (!String.IsNullOrEmpty(username))
            {
                HttpContext.Session.SetString(SessionKeyName, username);
                //if (await _context.ZooUsers.Where(username == a.UserName))
                //ZooUsers = await _context.ZooUsers.Where(a => a.UserName==username && a => a.AuthenticationKey==password);
            }
        }
        /*public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "Default");
            }
            var name = HttpContext.Session.GetString(SessionKeyName);

            _logger.LogInformation("Session Name: {Name}", name);
        }*/
    }

}
