using Microsoft.AspNetCore.Mvc;

namespace SafariSoul.Views
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View("/SafariSoul/Views/Administrator");
        }

        public ActionResult MyAction()
        {
            return View("/SafariSoul/Views/Administrator");
        }
    }
}
