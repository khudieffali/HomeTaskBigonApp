using Azure.Core;
using Bigon.Business.Modules.BlogCategoriesModule.Queries.BlogCategoryGetAllQuery;
using Bigon.Business.Modules.CategoriesModule.Commands.CategoryAddCommands;
using Bigon.Business.Modules.CategoriesModule.Commands.CategoryRemoveCommands;
using Bigon.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
    [Area(nameof(BigonAdmin))]
    public class CategoryController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IActionResult> Index(CategoryGetAllRequest request)
        {
            var response=await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.CategoryList = new SelectList(categories, "Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest request)
        {
            var response = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(CategoryGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(CategoryRemoveRequest request)
        {
            var response = await _mediator.Send(request);
            return PartialView("_Body",response);
        }
    }
}
