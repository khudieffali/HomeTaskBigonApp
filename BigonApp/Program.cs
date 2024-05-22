using BigonApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cString = builder.Configuration.GetConnectionString("BigonDB");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(cString,
    cfg => cfg.MigrationsHistoryTable("Migrations")));



var app = builder.Build();
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
app.UseStaticFiles();
app.Run();
