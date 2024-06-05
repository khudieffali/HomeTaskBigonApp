using Bigon.Business.Modules.ColorsModule.Commands.ColorsAddCommands;
using Bigon.Business.Modules.ColorsModule.Commands.ColorsDeleteCommands;
using Bigon.Business.Modules.ColorsModule.Commands.ColorsEditCommands;
using Bigon.Business.Modules.ColorsModule.Queries.ColorsGetAllQuery;
using Bigon.Business.Modules.ColorsModule.Queries.ColorsGetQuery;
using Bigon.Data.Persistance;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class ColorController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;
        public async Task<IActionResult> Index(ColorsGetAllRequest request)
        {

          IEnumerable<Color> colorList=await _mediator.Send(request);
           return View(colorList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorsAddRequest request)
        {
            await _mediator.Send(request);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(ColorsGetRequest request)
        {
            var color = await _mediator.Send(request);
            if (color == null) return NotFound();
            return View(color);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ColorsEditRequest request)
        {
            var dbColor =await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(ColorsGetRequest request)
        {

            var dbColor = await _mediator.Send(request);
            if (dbColor == null) return NotFound();
            return View(dbColor);
        }

        public async Task<IActionResult> Remove(ColorsDeleteRequest request)
        {
          var colorList = await _mediator.Send(request);
           return PartialView("_Body", colorList);
        }
    }
}

