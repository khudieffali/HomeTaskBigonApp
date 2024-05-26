using BigonApp.Models;
using BigonApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BigonApp.Controllers
{
    public class HomeController(DataContext context) : Controller
    {
        private readonly DataContext _context=context;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string email)
        {
            if (email == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Please fill in the box"
                });
            }
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                return Json(new
                {
                    error = true,
                    message = "Please enter a valid email"
                });
            }
           var dbEmail=_context.Subscribers.FirstOrDefault(x=>x.EmailAddress==email);
            if (dbEmail != null && !dbEmail.IsApproved) 
            {
                return Json(new
                {
                    error = true,
                    message= "This email already exists, please confirm"
                });

            }
            var subscriber = new Subscriber
            {
                EmailAddress = email,
                CreatedAt = DateTime.Now, 
            };
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();
            return Ok(new
            {
                success=true,
                message=$"{email} successfully registered"
            });
        }
    }
}
