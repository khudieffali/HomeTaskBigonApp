using Bigon.Data.Persistance;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class TagController(ITagRepository tagRepository) : Controller
    {
       private readonly ITagRepository _tagRepository=tagRepository;
        public IActionResult Index()
        {
            var tagList = _tagRepository.GetAll(x => x.DeletedBy == null);
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
            await _tagRepository.Add(tag);
            await _tagRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var dbTag =await _tagRepository.GetById(x=>x.Id==id);
            if (dbTag == null) return NotFound();
            return View(dbTag);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tag? tag)
        {
            if(tag == null) return NotFound();
            var dbTag =await _tagRepository.GetById(x=>x.Id==tag.Id);
            if(dbTag == null) return NotFound();
            dbTag.Name= tag.Name;
            await _tagRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var dbTag =await _tagRepository.GetById(x=>x.Id==id);
            if (dbTag == null) return NotFound();
            return View(dbTag);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var dbTag =await _tagRepository.GetById(x=>x.Id==id);
            if (dbTag == null)
                return Json(new
                {
                    error = true,
                    message = "Data was not found"
                });
            _tagRepository.Remove(dbTag);
             _tagRepository.Save();
            var tagList = _tagRepository.GetAll(x => x.DeletedBy == null);

            return PartialView("_Body", tagList);
        }

    }
}
