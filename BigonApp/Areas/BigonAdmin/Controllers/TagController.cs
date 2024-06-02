using Bigon.Data.Persistance;
using Bigon.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class TagController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        public IActionResult Index()
        {
            List<Tag> tagList = [.. _context.Tags.Where(x => x.DeletedBy == null)];
            return View(tagList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (tag == null) return NotFound();
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var dbTag =await _context.Tags.FindAsync(id);
            if (dbTag == null) return NotFound();
            return View(dbTag);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tag? tag)
        {
            if(tag == null) return NotFound();
            var dbTag =await  _context.Tags.FindAsync(tag.Id);
            dbTag.Name= tag.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var dbTag =await _context.Tags.FindAsync(id);
            if (dbTag == null) return NotFound();
            return View(dbTag);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var dbTag = _context.Tags.Find(id);
            if (dbTag == null)
                return Json(new
                {
                    error = true,
                    message = "Data was not found"
                });
            _context.Tags.Remove(dbTag);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                error=false,
                message= "Your data has been successfully deleted"
            });
        }

    }
}
