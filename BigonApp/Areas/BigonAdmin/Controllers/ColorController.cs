using BigonApp.Models;
using BigonApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class ColorController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        public IActionResult Index()
        {
            List<Color> colorList = [.. _context.Colors];
            return View(colorList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            color.CreatedAt = DateTime.Now;
            color.CreatedBy = 1;
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
