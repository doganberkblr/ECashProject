﻿using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ECashProject.DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PresentationLayer.Models;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<Context>(options =>
        options.UseSqlServer("Server=localhost,1433;Database=ECashDb;User ID=SA;Password=reallyStrongPwd123;"));

    services.AddControllersWithViews();
}
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountProcessDAL, EfCustomerAccountProcessDAL>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

builder.Services.AddScoped<ICustomerAccountDAL, EfCustomerAccountDAL>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>(); 

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

