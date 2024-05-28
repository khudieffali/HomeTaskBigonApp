using BigonApp.Helpers.Services;
using BigonApp.Models;
using BigonApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace BigonApp.Controllers
{
    public class HomeController(DataContext context,IEmailService emailService) : Controller
    {
        private readonly DataContext _context=context;
        private readonly IEmailService _emailService=emailService;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string email)
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
            if (dbEmail != null && dbEmail.IsApproved)
            {
                return Json(new
                {
                    success = true,
                    message = "This email is already subscribed"
                });

            }
            var subscriber = new Subscriber
            {
                EmailAddress = email,
                CreatedAt = DateTime.Now, 
            };
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();

            string token = $"#demo-{subscriber.EmailAddress}-{subscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";
            token = HttpUtility.UrlEncode(token);

            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";
            string body = $"Please click to link accept subscription <a href=\"{url}\">Click!</a>";

            await _emailService.SendEmailAsync(email,"Ali Xudiyev",body);
            return Ok(new
            {
                success=true,
                message=$"{email} successfully registered, please confirm"
            });
        }

        [Route("/subscribe-approve")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            string pattern=@"#demo-(?<email>[^-]*)-(?<date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})-bigon";
            Match match = Regex.Match(token, pattern);  
            if (!match.Success) 
            {
                return Content("token is broken");

            }

            string email = match.Groups["email"].Value;
            string dateS = match.Groups["date"].Value;
            if (!DateTime.TryParseExact(dateS, "yyyy-MM-dd HH:mm:ss.fff", null, DateTimeStyles.None, out DateTime date))
            {
                return Content("token is broken");
            }
            var subscriber=await _context.Subscribers.FirstOrDefaultAsync(x=>x.EmailAddress.Equals(email) &&x.CreatedAt==date);
            if (subscriber == null)
            {
                return Content("token is broken");

            }
            if (!subscriber.IsApproved)
            {
                subscriber.IsApproved=true;
                subscriber.ApprovedAt=DateTime.Now;
            }
            await _context.SaveChangesAsync();
            return Content($"Success:Email: {email}\n" + $"DateTime: {date}");


        }
       
    }
}
