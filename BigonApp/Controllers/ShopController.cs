using BigonApp.Models;
using BigonApp.Models.Entities;
using BigonApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class ShopController(DataContext context) : Controller
    {
        private readonly DataContext _context=context;
        public IActionResult Index()
        {
            List<Brand> brandList = [.. _context.Brands];
            ShopVM vm = new() { BrandList = brandList };
            return View(vm);
        }
    }
}
