using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
