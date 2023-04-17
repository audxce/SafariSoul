using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SafariSoul.Pages.DefaultPages
{
    public class HomeModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyType = "_Type";
        public const string SessionKeyCID = "_CustID";
        public const string SessionKeyEID = "_EmpID";

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
                HttpContext.Session.SetString(SessionKeyType, "Default");
                HttpContext.Session.SetString(SessionKeyCID, "Default");
                HttpContext.Session.SetString(SessionKeyEID, "Default");
            }
            var name = HttpContext.Session.GetString(SessionKeyName);
            var type = HttpContext.Session.GetString(SessionKeyType);
            var custid = HttpContext.Session.GetString(SessionKeyCID);
            var empid = HttpContext.Session.GetString(SessionKeyEID);

            _logger.LogInformation("Session Name: {Name}", name);
            _logger.LogInformation("Session Type: {Type}", type);
            //_logger.LogInformation("Session Customer: {ID}", custid);
            //_logger.LogInformation("Session Employee: {ID}", empid);
        }
    }
}
