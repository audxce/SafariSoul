using Microsoft.AspNetCore.Mvc;

namespace SafariSoul.Views
{
    public class DefaultUser : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
