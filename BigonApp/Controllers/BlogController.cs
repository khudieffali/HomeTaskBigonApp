using BigonApp.Models;
using BigonApp.Models.Entities;
using BigonApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class BlogController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Details()
        {
            Blog? blog = _context.Blogs.FirstOrDefault();
            List<Tag> tagList = [.. _context.Tags.Where(x=>x.DeletedBy==null)];
            BlogVM vm = new() { Blog = blog,TagList=tagList };
            return View(vm);
        }
    }
}
