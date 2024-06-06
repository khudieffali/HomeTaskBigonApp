using Azure;
using Bigon.Business.Modules.TagsModule.Commands.TagsAddCommands;
using Bigon.Business.Modules.TagsModule.Commands.TagsDeleteCommands;
using Bigon.Business.Modules.TagsModule.Commands.TagsEditCommands;
using Bigon.Business.Modules.TagsModule.Queries.TagsGetAllQuery;
using Bigon.Business.Modules.TagsModule.Queries.TagsGetQuery;
using Bigon.Data.Persistance;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class TagController(IMediator mediator) : Controller
    {
       private readonly IMediator _mediator=mediator;
        public async Task<IActionResult> Index(TagsGetAllRequest request)
        {
            var tagList = await _mediator.Send(request);
            return View(tagList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TagsAddRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(TagsGetRequest request)
        {
            var dbTag =await _mediator.Send(request);
            if (dbTag == null) return NotFound();
            return View(dbTag);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TagsEditRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(TagsGetRequest request)
        {
            var dbTag = await _mediator.Send(request);
            if (dbTag == null) return NotFound();
            return View(dbTag);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(TagsDeleteRequest request)
        {

            var tagList =await _mediator.Send(request);
            return PartialView("_Body", tagList);
        }

    }
}
