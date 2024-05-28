using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area(nameof(BigonAdmin))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
