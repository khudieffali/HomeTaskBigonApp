using Azure.Core;
using Bigon.Business.Modules.BlogCategoriesModule.Queries.BlogCategoryGetAllQuery;
using Bigon.Business.Modules.BlogsModule.Commands.BlogAddCommands;
using Bigon.Business.Modules.BlogsModule.Commands.BlogEditCommands;
using Bigon.Business.Modules.BlogsModule.Commands.BlogRemoveCommands;
using Bigon.Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using Bigon.Business.Modules.BlogsModule.Queries.BlogGetByIdQuery;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BigonApp.Areas.BigonAdmin.Controllers
{
        [Area(nameof(BigonAdmin))]
    public class BlogController(DbContext context,
            IWebHostEnvironment webHostEnvironment,
            IMediator mediator) : Controller
    {
        private readonly DbContext _context = context;
        private readonly IWebHostEnvironment _webHostEnvironment=webHostEnvironment;
        private readonly IMediator _mediator = mediator;

        public  async Task<IActionResult> Index(BlogGetAllRequest request)
        {
            var blogList = await _mediator.Send(request);
            return View(blogList);
        }

        public async Task<IActionResult> Create()
        {
            var BlogCategoryList =await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.BlogCategories = new SelectList(BlogCategoryList, "Id", "Name");
            return View();
        }   

        [HttpPost]
        public async Task<IActionResult> Create(BlogAddRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
       

        public async Task<IActionResult> Edit(BlogGetByIdRequest request)
        {
            var BlogCategoryList = await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.BlogCategories = new SelectList(BlogCategoryList, "Id", "Name");
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogEditRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(BlogGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(BlogRemoveRequest request)
        {
            var response = await _mediator.Send(request);
            return PartialView("_Body",response);
        }


    }
}
