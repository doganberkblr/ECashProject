using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ECashProject.DataAccessLayer.Concrete;


void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<Context>(options =>
        options.UseSqlServer("Server=localhost,1433;Database=ECashDb;User ID=SA;Password=reallyStrongPwd123;")); // YourConnectionString yerine veritabanı bağlantı dizesini girin

    services.AddControllersWithViews();
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

