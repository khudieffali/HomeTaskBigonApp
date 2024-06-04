using Bigon.Data.Persistance;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class ColorController(IColorRepository colorRepository) : Controller
    {
        private readonly IColorRepository _colorRepository = colorRepository;
        public IActionResult Index()
        {

          IEnumerable<Color> colorList= _colorRepository.GetAll(x=>x.DeletedBy==null);
           return View(colorList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            await _colorRepository.Add(color);
            await _colorRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var color = await _colorRepository.GetById(x => x.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Color color)
        {
            var dbColor = await _colorRepository.GetById(x => x.Id == color.Id);
            if (dbColor == null)
              return NotFound();
             _colorRepository.Edit(dbColor);
            await _colorRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {

            var dbColor = await _colorRepository.GetById(x => x.Id ==id);
            if (dbColor == null) return NotFound();
            return View(dbColor);
        }

        public async  Task<IActionResult> Remove(int id)
        {
            var color = await _colorRepository.GetById(x=>x.Id==id);
            if (color == null)
                return Json(new
                {
                    error = true,
                    message = "Data was not found!"
                });
             _colorRepository.Remove(color);
             _colorRepository.Save();
            IEnumerable<Color> colorList = _colorRepository.GetAll(x=>x.DeletedBy==null);
            return PartialView("_Body",colorList);
        }
    }
}
