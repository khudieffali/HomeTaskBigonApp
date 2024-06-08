using Bigon.Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
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
            IFileService fileService,
            IMediator mediator) : Controller
    {
        private readonly DbContext _context = context;
        private readonly IWebHostEnvironment _webHostEnvironment=webHostEnvironment;
        private readonly IFileService  _fileService= fileService;
        private readonly IMediator _mediator = mediator;

        public  async Task<IActionResult> Index(BlogGetAllRequest request)
        {
            var blogList = await _mediator.Send(request);
            return View(blogList);
        }

        public IActionResult Create()
        {
            var BlogCategoryList = _context.Set<BlogCategory>().ToList();
            ViewBag.BlogCategories = new SelectList(BlogCategoryList, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog, IFormFile ImagePath)
        {
            var fileName=await _fileService.UploadFileAsync(ImagePath);
            var newBlog = new Blog
            {
                Name = blog.Name,
                Description = blog.Description,
                ImagePath = fileName,
                Slug = blog.Name,
                BlogCategoryId =blog.BlogCategoryId
            };
            await _context.Set<Blog>().AddAsync(newBlog);
            await _context.SaveChangesAsync();
            return View();
        }

    }
}
