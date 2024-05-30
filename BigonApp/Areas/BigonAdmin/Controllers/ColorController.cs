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
            List<Color> colorList = [.. _context.Colors.Where(x => x.DeletedBy == null)];
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

        public async Task<IActionResult> Edit(int id)
        {
            var color = _context.Colors.Find(id);
            if (color == null) return NotFound();
            return View(color);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Color color)
        {
            var dbColor = _context.Colors.Find(color.Id);
            if (dbColor == null)
              return NotFound();
            dbColor.Name = color.Name;
            dbColor.HexCode = color.HexCode;
            dbColor.ModifiedBy = 2;
            dbColor.ModifiedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {

            var color = _context.Colors.Find(id);
            if (color == null) return NotFound();
            return View(color);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var color = _context.Colors.Find(id);
            if (color == null)
                return Json(new
                {
                    error = true,
                    message = "Data was not found!"
                });
            color.DeletedAt = DateTime.UtcNow;
            color.DeletedBy = 3;
            await _context.SaveChangesAsync();
            return Ok(new
            {
                error = false,
                message = "Your data has been successfully deleted"
            });
        }
    }
}
