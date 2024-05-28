using BigonApp.Helpers;
using BigonApp.Helpers.Services;
using BigonApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cString = builder.Configuration.GetConnectionString("BigonDB");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(cString,
    cfg => cfg.MigrationsHistoryTable("Migrations")));


var emailConfig = builder.Configuration.GetSection("emailSender");
builder.Services.Configure<EmailOptions>(cfg =>
{
    emailConfig.Bind(cfg);
});

builder.Services.AddSingleton<IEmailService,EmailService>();


var app = builder.Build();
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
app.UseStaticFiles();
app.Run();
